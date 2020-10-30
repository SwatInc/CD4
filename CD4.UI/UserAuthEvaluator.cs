using CD4.UI.Extensions;
using CD4.UI.Library.Model;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD4.UI
{
    public class UserAuthEvaluator : IUserAuthEvaluator
    {
        private readonly AuthorizeDetailEventArgs _authArgs;

        public UserAuthEvaluator(AuthorizeDetailEventArgs authArgs)
        {
            _authArgs = authArgs;
        }
        public bool EvaluateAuthForItem<T>(T view) where T : Form
        {
            //decide access to view
            var viewClaim = (string)view.Tag;
            if (!string.IsNullOrEmpty(viewClaim))
            {
                //look for the same claim in the user/role claims
                if (!DoesUserClaimAccess(viewClaim))
                {
                    return false;
                }

                //get all buttons to evaluate disabling
                var buttons = view.Descendants<SimpleButton>().Where((x) => !string.IsNullOrEmpty((string)x.Tag));
                if (buttons.Count() > 0)
                {
                    //Iterate all buttons which needs to be claimed by user
                    foreach (var button in buttons)
                    {
                        //disable the button if the user does not claim them
                        if (!DoesUserClaimAccess((string)button.Tag)) button.Enabled = false;
                    }
                }

            }
            return true;
        }

        public bool IsFunctionAuthorized(string requiredClaim)
        {
            if (!_authArgs.IsFunctionAuthorized(requiredClaim, out var claim))
            {
                _ = XtraMessageBox.Show($"Function, [ {requiredClaim} ] is not authorized for user {_authArgs.Username}.");
                return false;
            }
            return true;
        }

        private bool DoesUserClaimAccess(string claim)
        {
            var IsClaimed =  !string.IsNullOrEmpty(_authArgs.Claims.Find((x) => x == claim));
            return IsClaimed;
        }


    }
}
