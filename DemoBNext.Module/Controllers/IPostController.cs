using DemoBNext.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBNext.Module.Controllers
{
    public class IPostController : ViewController
    {
        SimpleAction Post;
        public IPostController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            this.TargetObjectType = typeof(IPost);
            Post = new SimpleAction(this, "Post", "View");
            Post.Execute += Post_Execute;
            
        }
        private void Post_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
           var IPostInstance= this.View.CurrentObject as IPost;
            IPostInstance.Post();
            this.View.ObjectSpace.CommitChanges();
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
