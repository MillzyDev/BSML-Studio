using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace BSMLStudio.UI.ViewControllers
{
    [ViewDefinition("BSMLStudio.UI.Views.StudioView.bsml")]
    class StudioViewController : BSMLAutomaticViewController
    {
        [Inject]
        private DisplayViewController displayViewController;

        private string currentFile = null;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            base.DidActivate(firstActivation, addedToHierarchy, screenSystemEnabling);

            if (firstActivation || currentFile == null)
            {
                displayViewController.Display(ResourceUtils.GetResourceContent("BSMLStudio.UI.Views.DisplayView.bsml"));
            }
        }

        [UIValue("file-choices")]
        public List<object> fileChoices = new object[] {}.ToList();
    }
}
