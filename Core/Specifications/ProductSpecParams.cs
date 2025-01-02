using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    // 這個class 是製作分頁過濾查詢的參數~
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }


        private List<string> _brands = [];
        public List<string> Brands
        {
            get => _brands; // type=boards,gloves
            set
            {
                // 因為query params 會有逗號，使用這個方式去除,
                _brands = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }
        private List<string> _types = [];
        public List<string> Types
        {
            get => _types; // type=boards,gloves
            set
            {
                // 因為query params 會有逗號，使用這個方式去除,
                _types = value.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();
            }
        }

        public string? Sort { get; set; }

        private string? _search;

        public string Search
        {
            get => _search ?? "";
            set => _search = value.ToLower();
        }

    }
}
