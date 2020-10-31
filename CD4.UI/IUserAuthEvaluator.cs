using DevExpress.XtraBars.Ribbon;
using System.Windows.Forms;

namespace CD4.UI
{
    public interface IUserAuthEvaluator
    {
        bool EvaluateAuthForItem<T>(T view) where T : Form;
        bool IsFunctionAuthorized(string requiredClaim, bool showMessage = true);
    }
}