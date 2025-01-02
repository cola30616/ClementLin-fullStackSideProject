namespace sp_skishop.RequestHelpers
{
    public class Pagination<T>(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
    {    
        // 這裡會決定回傳出去的JSON 格式

        public int PageIndex{ get; set; } = pageIndex;
        public int PageSize { get; set; } = pageSize;

        public int Count { get; set; }=count;

        public IReadOnlyList<T> Data { get; set; } = data;
    }
}
