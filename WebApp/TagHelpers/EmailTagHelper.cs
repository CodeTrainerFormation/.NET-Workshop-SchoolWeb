using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.TagHelpers
{
	public class EmailTagHelper : TagHelper
	{
		public string MailTo { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "a";    // Replaces <email> with <a> tag

			var address = MailTo + "@contoso.com";
			output.Attributes.SetAttribute("href", "mailto:" + address); output.Content.SetContent(address);
		}
	}

}
