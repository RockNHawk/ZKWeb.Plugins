﻿using DryIocAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKWeb.Localize.Interfaces;
using ZKWeb.Utils.Extensions;

namespace ZKWeb.Plugins.Common.CustomTranslate.src.Translates {
	/// <summary>
	/// 繁体中文翻译
	/// </summary>
	[ExportMany, SingletonReuse]
	public class zh_TW : ITranslateProvider {
		private static HashSet<string> Codes = new HashSet<string>() { "zh-TW" };
		private static Dictionary<string, string> Translates = new Dictionary<string, string>()
		{
			{ "CustomTranslate", "定制翻譯" },
			{ "Support custom translate through admin panel", "支持在管理後台中設置定制翻譯" },
			{ "Translation", "翻譯內容" },
			{ "Origin/Translated", "原文/譯文" },
			{ "OriginalText", "原文" },
			{ "TranslatedText", "譯文" },
			{ "Are you sure to delete this translation?", "確認要刪除這條翻譯內容？" }
		};

		public bool CanTranslate(string code) {
			return Codes.Contains(code);
		}

		public string Translate(string text) {
			return Translates.GetOrDefault(text);
		}
	}
}
