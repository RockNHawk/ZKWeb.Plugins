﻿using System;
using System.Collections.Generic;
using ZKWeb.Plugins.Common.Admin.src.Components.PrivilegeProviders;
using ZKWeb.Plugins.Common.Admin.src.Components.ScaffoldAttributes;
using ZKWeb.Plugins.Common.Admin.src.Controllers.Interfaces;
using ZKWeb.Plugins.Common.Admin.src.Domain.Entities.Interfaces;
using ZKWeb.Plugins.Common.Admin.src.Domain.Services;
using ZKWeb.Plugins.Common.Base.src.Controllers.Bases;
using ZKWeb.Web;

namespace ZKWeb.Plugins.Common.Admin.src.Controllers.Bases {
	/// <summary>
	/// 简单的后台控制器的基础类
	/// </summary>
	public abstract class SimpleAdminAppControllerBase :
		ScaffoldControllerBase,
		IPrivilegesProvider, IWebsiteStartHandler, IAdminAppController {
		/// <summary>
		/// 分组名称
		/// </summary>
		public virtual string Group { get { return "Other"; } }
		/// <summary>
		/// 分组图标的css类
		/// </summary>
		public virtual string GroupIconClass { get { return "fa fa-archive"; } }
		/// <summary>
		/// 应用名称
		/// </summary>
		public abstract string Name { get; }
		/// <summary>
		/// url地址
		/// </summary>
		public abstract string Url { get; }
		/// <summary>
		/// 格式的css类名
		/// </summary>
		public virtual string TileClass { get { return "tile bg-navy"; } }
		/// <summary>
		/// 图标的css类名
		/// </summary>
		public virtual string IconClass { get { return "fa fa-archive"; } }
		/// <summary>
		/// 显示此应用要求的用户类型
		/// </summary>
		public virtual Type RequiredUserType { get { return typeof(IAmAdmin); } }
		/// <summary>
		/// 显示此应用要求的权限列表
		/// </summary>
		public virtual string[] RequiredPrivileges { get { return new string[0]; } }
		/// <summary>
		/// 对应的处理函数，会自动进行权限检查
		/// </summary>
		/// <returns></returns>
		[ScaffoldAction(nameof(Url), HttpMethods.GET)]
		[ScaffoldAction(nameof(Url), HttpMethods.POST)]
		[ScaffoldCheckPrivilege(nameof(RequiredUserType), nameof(RequiredPrivileges))]
		protected abstract IActionResult Action();

		/// <summary>
		/// 获取权限列表
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerable<string> GetPrivileges() {
			foreach (var privilege in RequiredPrivileges) {
				yield return privilege;
			}
		}
	}
}
