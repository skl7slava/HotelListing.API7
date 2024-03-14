﻿namespace HotelListing.Api.Models
{
    public class QueryParameters
    {
        private int _pageSize = 15;
        public int StartIndex { get; set; }
        public int PageNumber { get; set; } = 0;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;  
            }
        }
    }
}
