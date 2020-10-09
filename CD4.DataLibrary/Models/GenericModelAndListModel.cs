using System.Collections.Generic;

namespace CD4.DataLibrary.Models
{
    public class GenericModelAndListModel
    {
        public GenericModelAndListModel GetNewModel<T, U>() where T: new()
        {
            T1 = new T();
            U1 = new List<U>();

            return this;
        }

        public dynamic T1 { get; set; }
        public dynamic U1 { get; set; }
    }
}
