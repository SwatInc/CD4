using System;
using System.Collections.Generic;

namespace CD4.UI.Library.Model
{
    public class AuthorizeDetailEventArgs : EventArgs
    {
        private string _claimsCsv;
        public AuthorizeDetailEventArgs()
        {
            Claims = new List<string>();
        }

        public void SetData(AuthorizeDetailEventArgs authorizeDetailEvent)
        {
            this.UserRole = authorizeDetailEvent.UserRole;
            this.Username = authorizeDetailEvent.Username;
            this.FullName = authorizeDetailEvent.FullName;
            this.ClaimsCsv = authorizeDetailEvent.ClaimsCsv;
            this.IsAuthenticated = authorizeDetailEvent.IsAuthenticated;
        }

        public string UserRole { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string ClaimsCsv
        {
            get => _claimsCsv; set
            {
                if (_claimsCsv == value) return;
                _claimsCsv = value;
                SetClaims();
            }
        }

        /// <summary>
        /// Generate a list of claims from ClaimsCsv
        /// </summary>
        private void SetClaims()
        {
            Claims.Clear();
            foreach (var claim in _claimsCsv.Split(','))
            {
                Claims.Add(claim);
            }
        }

        public bool IsAuthenticated { get; set; }
        public string Message { get; set; }
        public List<string> Claims { get; set; }

        /// <summary>
        /// checks for the presence of the claim passed-in in the user claims
        /// </summary>
        /// <param name="claim">The claim to be searched for</param>
        /// <returns>True if the claim is found. False if the claim is not found</returns>
        public bool IsFunctionAuthorized(string claim, out string searchedClaim)
        {
            searchedClaim = claim;
            return !string.IsNullOrEmpty(Claims.Find((x) => x == claim));
        }
    }
}
