using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI.View
{
    public partial class PatientDetailsConfirmationView : DevExpress.XtraEditors.XtraForm
    {
        [Browsable(false)] public new DialogResult DialogResult { get; set; }
        private string NidPp { get; set; }
        public PatientDetailsConfirmationView(DemographicsConfirmationModel confirmationModel)
        {
            InitializeComponent();
            textEditNidPp.TextChanged += CompareNidPp;
            EnableDisableButtonVerify();
            simpleButtonVerified.Click += DemographicsConfirmed;
            simpleButtonCancel.Click += CannotConfrirmDemographics;

            SetData(confirmationModel);
        }

        private void CannotConfrirmDemographics(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void DemographicsConfirmed(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CompareNidPp(object sender, EventArgs e)
        {
            if (textEditNidPp.Text == NidPp)
            {
                EnableDisableButtonVerify(true);
            }
            else
            {
                EnableDisableButtonVerify();
            }
        }

        private void EnableDisableButtonVerify(bool isEnable = false)
        {
            simpleButtonVerified.Enabled = isEnable;
        }

        private void SetData(DemographicsConfirmationModel confirmationModel)
        {
            this.LabelPatientName.Text = confirmationModel.Patient.Fullname;
            this.labelDob.Text = confirmationModel.Patient.Birthdate.ToString("yyyy-MMM-dd");
            this.labelAge.Text = confirmationModel.Age;
            this.labelGender.Text = confirmationModel.Patient.Gender;
            this.NidPp = confirmationModel.Patient.NidPp;
            this.labelContactNo.Text = confirmationModel.Patient.PhoneNumber;
        }

    }
}