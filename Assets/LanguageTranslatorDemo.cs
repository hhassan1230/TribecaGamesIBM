using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IBM.Watson.DeveloperCloud.Services.LanguageTranslator.v2;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.Connection;

public class LanguageTranslatorDemo : MonoBehaviour {

	public Text ResponseTextField;
	public string translateString = "Where is the library";

	private LanguageTranslator _languageTranslator;
	private string _translatorModel = "en-es";
	// Use this for initialization
	void Start () {
		LogSystem.InstallDefaultReactors();

		Credentials languageTranslatorCredentials = new Credentials() {
			Username = "GO ON SLACK",
			Password = "GO ON SLACK",
			Url = "https://gateway.watsonplatform.net/language-translator/api"
		};

		_languageTranslator = new LanguageTranslator(languageTranslatorCredentials);

		Translate(translateString);
	}

	public void Translate(string text) 
	{
		_languageTranslator.GetTranslation(OnTranslate, OnFail, text, _translatorModel);
	}
	
	public void OnTranslate(Translations response, Dictionary<string, object> customData) {
		ResponseTextField.text = response.translations[0].translation;
	}

	public void OnFail(RESTConnector.Error error, Dictionary<string, object> customData) {
		Log.Debug("LanguageTranslatorDame.OnFail()", "Error: {0}", error.ToString());
	}
}
