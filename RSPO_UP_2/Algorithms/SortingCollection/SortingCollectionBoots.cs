﻿using System.Linq;
using RSPO_UP_2.View;

namespace RSPO_UP_2.Algorithms.SortingCollection
{
    public class SortingCollectionBoots
    {
        public void SortByPrice()
        {
            var list = DbCollectionHelper.GetBoots();
            var sortedList = list.OrderBy(x => x.Price);
            ShowInfoView.PrintList(sortedList);
        }

        public void SortByCount()
        {
            var list = DbCollectionHelper.GetBoots();
            var sortedList = list.OrderBy(x => x.Count);
            ShowInfoView.PrintList(sortedList);
        }

        public void SortByCategoryName()
        {
            var list = DbCollectionHelper.GetBoots();
            var sortedList = list.OrderBy(x => x.CategoryName);
            ShowInfoView.PrintList(sortedList);
        }

        public void SortByName()
        {
            var list = DbCollectionHelper.GetBoots();
            var sortedList = list.OrderBy(x => x.ProductName);
            ShowInfoView.PrintList(sortedList);
        }
    }
}
