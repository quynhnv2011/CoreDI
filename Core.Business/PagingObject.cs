using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Core.DataAccess
{
    public class PagingObject
    {
        public PagingObject()
        {
            IsNotPaging = false;
        }
        public bool IsNotPaging { get; set; }
        public int PageIndex
        {
            get
            {
                var p = HttpContext.Current.Request["pageIndex"];
                return p != null ? Common.Extensions.ConvertExtensions.AsInt(p) : 1;
            }
        }
        public int PageSize
        {
            get
            {
                if (IsNotPaging) return 99999999;
                var p = System.Web.HttpContext.Current.Request["pagesize"];
                return p != null ? Common.Extensions.ConvertExtensions.AsInt(p) : 50;
            }
            set { }
        }
        public int TotalItem { get; set; }

        public string GetHtmlPaging
        {
            get
            {
                var str = new StringBuilder();
                str.Append("<div class=\"wr-pagination\">");
                str.Append("<div class=\"pagination\">");
                var strUrl = System.Web.HttpContext.Current.Request.RawUrl;

                if (System.Web.HttpContext.Current.Request.QueryString.Count == 0)
                {
                    strUrl += "?pageIndex={0}";
                }
                else
                {
                    if (strUrl.IndexOf(string.Format("&pageIndex={0}", PageIndex), System.StringComparison.Ordinal) > 0)
                        strUrl = strUrl.Replace(string.Format("&pageIndex={0}", PageIndex), "&pageIndex={0}");
                    else if (strUrl.IndexOf(string.Format("?pageIndex={0}", PageIndex), System.StringComparison.Ordinal) > 0)
                        strUrl = strUrl.Replace(string.Format("?pageIndex={0}", PageIndex), "?pageIndex={0}");
                    else if (System.Web.HttpContext.Current.Request["pageIndex"] == null)
                    {
                        strUrl += "&pageIndex={0}";
                    }
                }

                if (TotalItem <= PageSize)
                {
                    return string.Empty;
                }

                if (PageSize == 0 || TotalItem == 0)
                {
                    return string.Empty;
                }
                var totalPage = TotalItem / PageSize;
                var dongdu = TotalItem % PageSize;
                if (dongdu != 0)
                {
                    totalPage = totalPage + 1;
                }

                if (totalPage == 1)
                {
                    return string.Empty;
                }

                if (PageIndex != 1)
                {
                    str.AppendFormat("<a href='{0}' onclick=\"BlockContent('.tab-content')\" class='prev'></a>", string.Format(strUrl, PageIndex - 1));
                }

                for (int i = 1; i <= totalPage; i++)
                {
                    if (i == PageIndex)
                    {
                        str.AppendFormat("<a href='javascript:void(0)' onclick=\"BlockContent('.tab-content')\" class='number selected'>{0}</z>", i);
                    }
                    else
                    {
                        if (i >= PageIndex - 5 && i <= PageIndex + 5)
                        {

                            str.AppendFormat("<a href='{0}' onclick=\"BlockContent('.tab-content')\" class='number'>{1}</a>", string.Format(strUrl, i), i);
                        }
                    }
                }

                if (PageIndex != totalPage)
                {
                    str.AppendFormat("<a href='{0}' onclick=\"BlockContent('.tab-content')\" class='next'></a>", string.Format(strUrl, PageIndex + 1));
                }

                str.Append("</div>");
                str.Append("</div>");
                return str.ToString();
            }
        }
    }
}
