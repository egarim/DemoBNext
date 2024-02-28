using DemoBNext.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBNext.Module.Controllers
{
    // xcv

    public class CustomerController : ViewController
    {
        SimpleAction Ejemplo2;
        SimpleAction ActivateCustomer;
        public CustomerController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.


            this.TargetObjectType = typeof(Customer);
            this.TargetViewType = ViewType.DetailView;
            //this.TargetViewId = "";

            //xas 

            ActivateCustomer = new SimpleAction(this, nameof(ActivateCustomer), "View");
            ActivateCustomer.Caption = "Activate Customer";
            ActivateCustomer.Execute += ActivateCustomer_Execute;


            Ejemplo2 = new SimpleAction(this, "Ejemplo 2", "View");
            Ejemplo2.Execute += Ejemplo2_Execute;
            

        }
        private void Ejemplo2_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
        }
        protected virtual void ActivateCustomer_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var CurrentCustomer=this.View.CurrentObject as Customer;

            CurrentCustomer.Active = true;


            var XpOs= this.View.ObjectSpace as XPObjectSpace;


           




            if (this.View.ObjectSpace.IsModified)
            {
                this.View.ObjectSpace.CommitChanges();
            }


            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
    }
}
