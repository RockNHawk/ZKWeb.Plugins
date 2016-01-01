﻿using DotLiquid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace ZKWeb.Plugins.Common.Base.src.TemplateTags {
	/// <summary>
	/// 引用javascript文件
	/// 必须使用在引用footer.html之前
	/// 例子
	/// {% include_js /static/common.base.js/test.js %}
	/// </summary>
	public class IncludeJs : Tag {
		/// <summary>
		/// 变量名
		/// </summary>
		public const string Key = "__js";

		/// <summary>
		/// 添加html到变量中，不重复添加
		/// </summary>
		public override void Render(Context context, TextWriter result) {
			var js = context[Key] as string ?? "";
			var html = string.Format(
				"<script src='{0}' type='text/javascript'></script>\r\n",
				HttpUtility.HtmlAttributeEncode(Markup.Trim()));
			if (!js.Contains(html)) {
				js += html;
				context[Key] = js;
			}
		}
	}
}