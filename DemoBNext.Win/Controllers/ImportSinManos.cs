using DemoBNext.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoBNext.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ImportSinManos : ViewController
    {
        SimpleAction Importart;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ImportSinManos()
        {
            InitializeComponent();

            Importart = new SimpleAction(this, "Importar", "View");
            Importart.Execute += Importart_Execute;
            
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void Importart_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var MyInstance = this.ObjectSpace.CreateObject(typeof(Customer)) as BaseObject;


            MyInstance.SetMemberValue("Name", "Rogelio");
            MyInstance.SetMemberValue("Active", false);

            var MemberInfo= MyInstance.ClassInfo.GetMember("Category");
            var CategoryClassInfo= MyInstance.Session.GetClassInfo(MemberInfo.MemberType);
            var CurrentBusinessKey= CategoryClassInfo.FindAttributeInfo(typeof(BusinessKeyAttribute)) as BusinessKeyAttribute;

            BinaryOperator CriteriaCode = new BinaryOperator(CurrentBusinessKey.Properties, "001");

            var Cat=  this.ObjectSpace.FindObject(MemberInfo.MemberType, CriteriaCode);

            MemberInfo.SetValue(MyInstance, Cat);

            if (this.ObjectSpace.IsModified)
            {
                this.ObjectSpace.CommitChanges();
            }
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
        }
        protected override void OnActivated()
        {
            base.OnActivated();
         

           
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
