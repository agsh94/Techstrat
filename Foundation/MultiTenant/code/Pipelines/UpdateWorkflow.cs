using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Events;
using Sitecore.SecurityModel;

namespace Sitecore.Foundation.MultiTenant.Pipelines
{
    public class UpdateWorkflow
    {
        public void OnItemSaved(object sender, EventArgs args)
        {
            var eventArgs = args as SitecoreEventArgs;

            var item = eventArgs?.Parameters[0] as Item;

            if (item != null)
            {
                if (ProcessShouldSkipped(item))
                {
                    return;
                }

                using (new SecurityDisabler())
                {
                    try
                    {
                        item.Editing.BeginEdit();
                        item.Fields["__Workflow state"].Value = Template.Fields.AwaitingApproval.ToString(); // Awaiting approval of Sample workflow
                        item.Editing.EndEdit(true);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static bool ProcessShouldSkipped(Item item)
        {
            return !item.Template.ID.Equals(Template.Fields.ArticleTemplateID);
        }
    }
}