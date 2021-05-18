using System;
using Sitecore.Data;
using Sitecore.Data.Items;
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
                    item.Editing.BeginEdit();
                    item.Fields["__Workflow state"].Value = "{46DA5376-10DC-4B66-B464-AFDAA29DE84F}"; // Awaiting approval of Sample workflow
                    item.Editing.EndEdit(true);
                }
            }
        }

        public static bool ProcessShouldSkipped(Item item)
        {
            return !item.Template.ID.Equals(new ID("{D5D8D41C-7421-4A26-9776-6A80C5857256}"));
        }
    }
}