using Autofac;
using System;
using System.Windows.Forms;

namespace CD4.UI
{
    public class AutofacFormFactory : IFormFactory
    {
        private readonly ILifetimeScope currentScope;

        public AutofacFormFactory(ILifetimeScope currentScope)
        {
            this.currentScope = currentScope;
        }

        public Form CreateForm(Type formType)
        {
            // begin a new lifetime scope for each form instance
            var scope = this.currentScope.BeginLifetimeScope();

            var form = (Form)scope.Resolve(formType);

            form.Disposed += (s, e) =>
            {
                // finish the scope when the form is disposed (closed)
                scope.Dispose();
            };

            return form;
        }
    }
}
