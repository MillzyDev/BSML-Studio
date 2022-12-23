using BeatSaberMarkupLanguage;
using HMUI;

namespace BSMLStudio.UI.ViewControllers
{
    class DisplayViewController : ViewController
    {  
        public void Display(string bsml)
        {
            BSMLParser.instance.Parse(bsml, gameObject);
        }
    }
}
