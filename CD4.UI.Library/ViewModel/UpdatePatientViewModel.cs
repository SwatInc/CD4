using AutoMapper;
using CD4.DataLibrary.DataAccess;
using CD4.UI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CD4.UI.Library.ViewModel
{
    public class UpdatePatientViewModel : INotifyPropertyChanged, IUpdatePatientViewModel
    {
        #region Private Properties
        private int? Id; //patient Id used to update all details including NidPp
        private string nidPp;
        private string fullname;
        private string address;
        private int selectedGenderId;
        private DateTime? birthdate;
        private string phoneNumber;
        private int nationalityId;
        private bool _isLoading;
        private string selectedAtoll;
        private string selectedIsland;
        private int selectedNationalityId;
        private readonly IMapper _mapper;
        private readonly IStaticDataDataAccess _staticDataAccess;
        private readonly IPatientDataAccess _patientDataAccess;
        #endregion

        private event EventHandler InitializeStaticData;


        public UpdatePatientViewModel(IMapper mapper, IStaticDataDataAccess staticData, IPatientDataAccess patientDataAccess)
        {
            _isLoading = false;
            Gender = new List<GenderModel>();
            Atolls = new List<AtollModel>();
            Islands = new List<IslandModel>();
            Nationalities = new List<CountryModel>();
            AllAtollsWithCorrespondingIsland = new List<AtollIslandModel>();

            _mapper = mapper;
            _staticDataAccess = staticData;
            this._patientDataAccess = patientDataAccess;
            InitializeStaticData += OnInitializeStaticDataAsync;
            InitializeStaticData(this, EventArgs.Empty);
        }

        #region INotifyPropertyChanged Hookup

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Public properties
        public string NidPp
        {
            get => nidPp; set
            {
                nidPp = value;
                OnPropertyChanged();
            }
        }
        public string Fullname
        {
            get => fullname; set
            {
                fullname = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address; set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public int SelectedGenderId
        {
            get => selectedGenderId; set
            {
                selectedGenderId = value;
                OnPropertyChanged();
            }
        }
        public DateTime? Birthdate
        {
            get => birthdate; set
            {
                birthdate = value;
                OnPropertyChanged();
            }
        }
        public string SelectedAtoll
        {
            get => selectedAtoll; set
            {
                selectedAtoll = value;
                OnPropertyChanged();
                RepopulateIslandDatasource(value).ConfigureAwait(true);
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber; set
            {
                phoneNumber = value;
                OnPropertyChanged();

            }
        }
        public int NationalityId
        {
            get => nationalityId; set
            {
                nationalityId = value;
                OnPropertyChanged();
            }
        }
        public string SelectedIsland
        {
            get => selectedIsland; set
            {
                selectedIsland = value;
                OnPropertyChanged();
            }
        }
        public int SelectedNationalityId
        {
            get => selectedNationalityId; set
            {
                selectedNationalityId = value;
                OnPropertyChanged();
            }
        }

        #region Lookup Lists
        public List<GenderModel> Gender { get; set; }
        public List<AtollModel> Atolls { get; set; }
        public List<IslandModel> Islands { get; set; }
        public List<CountryModel> Nationalities { get; set; }
        public List<AtollIslandModel> AllAtollsWithCorrespondingIsland { get; set; }

        #endregion
        #endregion

        #region Public Methods
        public async Task LoadPatientByNidPp()
        {
            try
            {
                _isLoading = true;
                //call db to load patient
                var patient = (await _patientDataAccess.GetPatientByNidPp(NidPp)).FirstOrDefault();
                var mappedPatient =  _mapper.Map<PatientModel>(patient);
                //reset form data
                ResetViewData();
                //display daya
                await DisplayDataOnViewAsync(mappedPatient);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _isLoading = false;
            }

        }

        public async Task UpdatePatientAsync()
        {
            try
            {
                _isLoading = true;
                //call db to update patient
                var patient = new PatientUpdateModel()
                {
                    Id = (int)Id,
                    Fullname = fullname,
                    NidPp = nidPp,
                    Birthdate = Birthdate.GetValueOrDefault().ToString("yyyyMMdd"),
                    GenderId = selectedGenderId,
                    AtollId = (AllAtollsWithCorrespondingIsland.Find((x)=> x.Atoll == SelectedAtoll && x.Island == SelectedIsland)).Id,
                    CountryId = SelectedNationalityId,
                    Address = Address,
                    PhoneNumber = PhoneNumber
                };
                var mappedPatient = _mapper.Map<DataLibrary.Models.PatientUpdateDatabaseModel>(patient);
                var updated = await _patientDataAccess.UpdatePatientByIdReturnInserted(mappedPatient);
                var updatedmapped = _mapper.Map<PatientUpdateModel>(updated);
                //reset form data
                ResetViewData();
                //display updated data on view
                await DisplayDataOnViewAsync(updatedmapped);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _isLoading = false;
            }
        }



        #endregion

        #region Private Methods
        private async Task DisplayDataOnViewAsync(PatientModel patientModel)
        {
            if(patientModel is null) { return; }
            Id = patientModel.Id;
            NidPp = patientModel.NidPp;
            Fullname = patientModel.Fullname;
            Address = patientModel.Address;
            SelectedGenderId = Gender.FirstOrDefault((x) => x.Gender == patientModel.Gender).Id;
            Birthdate = patientModel.Birthdate;
            SelectedAtoll = patientModel.Atoll;
            await RepopulateIslandDatasource(SelectedAtoll);
            SelectedIsland = patientModel.Island;
            PhoneNumber = patientModel.PhoneNumber;
            SelectedNationalityId = Nationalities.FirstOrDefault((x) => x.Country == patientModel.Country).Id;

        }
        private async Task DisplayDataOnViewAsync(PatientUpdateModel patientUpdateModel)
        {
            if (patientUpdateModel is null) { return; }
            Id = patientUpdateModel.Id;
            NidPp = patientUpdateModel.NidPp;
            Fullname = patientUpdateModel.Fullname;
            Address = patientUpdateModel.Address;
            SelectedGenderId = patientUpdateModel.GenderId;
            Birthdate = DateTime.Parse(patientUpdateModel.Birthdate);

            var atollData = AllAtollsWithCorrespondingIsland.Find((x) => x.Id == patientUpdateModel.AtollId);
            
            SelectedAtoll = (atollData).Atoll;
            await RepopulateIslandDatasource(SelectedAtoll);
            SelectedIsland = atollData.Island;
            PhoneNumber = patientUpdateModel.PhoneNumber;
            SelectedNationalityId = patientUpdateModel.CountryId;

        }
        private void ResetViewData()
        {
            Id = null;
            NidPp = string.Empty;
            Fullname = string.Empty;
            Address = string.Empty;
            SelectedGenderId = -1;
            Birthdate = null;
            SelectedAtoll = string.Empty; 
            PhoneNumber = string.Empty;
            SelectedNationalityId = -1;
            SelectedIsland = string.Empty;


        }
        private async void OnInitializeStaticDataAsync(object sender, EventArgs e)
        {
            _isLoading = true;

            try
            {
                await LoadAllNationalitiesAsync();
                await LoadAllGenderAsync();
                await LoadAllAtollsAndIslandsAsync();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _isLoading = false;
            }

            InitializeAtollsDatasource();
        }
        private async Task LoadAllNationalitiesAsync()
        {

            var results = await _staticDataAccess.GetAllCountriesAsync();

            foreach (var item in results)
            {
                Nationalities.Add(_mapper.Map<CountryModel>(item));
            }

        }
        private async Task LoadAllGenderAsync()
        {

            var results = await _staticDataAccess.GetAllGenderAsync();
            foreach (var item in results)
            {
                Gender.Add(_mapper.Map<GenderModel>(item));
            }

        }
        private async Task LoadAllAtollsAndIslandsAsync()
        {
            var results = await _staticDataAccess.GetAllAtollsAndIslandsAsync();
            foreach (var item in results)
            {
                AllAtollsWithCorrespondingIsland.Add(_mapper.Map<AtollIslandModel>(item));
            }
        }

        /// <summary>
        /// Adds distinct atoll letters to the datasource for 
        /// atoll selection by user.
        /// </summary>
        private void InitializeAtollsDatasource()
        {
            var distinctAtoll = AllAtollsWithCorrespondingIsland
                .Select((a) => a.Atoll).Distinct();

            var counter = 1;
            foreach (var item in distinctAtoll)
            {
                Atolls.Add(new AtollModel() { Id = counter, Atoll = item });
                counter++;
            }
        }
        private async Task RepopulateIslandDatasource(string atoll)
        {
            if (string.IsNullOrEmpty(atoll)) return;
            var islandSearchResults = await SearchIslandsByAtoll
                                                (GetAtollByName(atoll));

            //Clear the island list and add the new islands
            Islands.Clear();
            foreach (var results in islandSearchResults)
            {
                Islands.Add(new IslandModel()
                { Id = results.Id, Island = results.Island });
            }

        }

        private async Task<List<AtollIslandModel>> SearchIslandsByAtoll(string atollName)
        {
            if (atollName is null) throw new ArgumentNullException(nameof(atollName));
            return await Task.Run(() =>
            {
                return AllAtollsWithCorrespondingIsland.FindAll((i) =>
                {
                    return i.Atoll == atollName;
                });
            });
        }
        private string GetAtollByName(string atollName)
        {
            if (string.IsNullOrEmpty(atollName)) return string.Empty;
            return Atolls.SingleOrDefault((a) => a.Atoll == atollName).Atoll;
        }

        #endregion
    }
}
