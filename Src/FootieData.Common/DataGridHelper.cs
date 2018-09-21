﻿using System;
using FootieData.Common.Options;
using FootieData.Entities;
using FootieData.Entities.ReferenceData;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FootieData.Common
{
    public class DataGridHelper
    {
        public static bool IsDataGridEmpty(DataGrid dataGrid)
        {
            var dataGridEmpty = false;

            if (dataGrid.Items.Count == 0)
            {
                dataGridEmpty = true;
            }
            else
            {
                if (dataGrid.Items.Count == 1)
                {
                    var noDataToShow = IsNoDataToShow(dataGrid);
                    if (noDataToShow)
                    {
                        dataGridEmpty = true;
                    }
                }                
            }

            return dataGridEmpty;
        }

        public static bool UpdatedWithinLastXSeconds(DateTime lastUpdatedDate, int refreshIntervalInSeconds, DateTime now)
        {
            var updatedWithinLastXSeconds = false;

            if (lastUpdatedDate > now.AddSeconds(-refreshIntervalInSeconds))
            {
                updatedWithinLastXSeconds = true;
            }

            return updatedWithinLastXSeconds;
        }

        public static void HideHeaderIfNoDataToShow(DataGrid dataGrid)
        {
            var noDataToShow = IsNoDataToShow(dataGrid);
            if (noDataToShow)
            {
                dataGrid.HeadersVisibility = DataGridHeadersVisibility.None;
            }
        }

        private static bool IsNoDataToShow(DataGrid dataGrid)
        {
            var firstItem = dataGrid.Items.GetItemAt(0);
            return firstItem.GetType() == typeof(NullReturn);
        }
    }
}




///// <summary>
///// Finds a Child of a given item in the visual tree. 
///// </summary>
///// <param name="parent">A direct parent of the queried item.</param>
///// <typeparam name="T">The type of the queried item.</typeparam>
///// <param name="childName">x:Name or Name of child. </param>
///// <returns>The first parent item that matches the submitted type parameter. 
///// If not matching item can be found, a null parent is being returned.</returns>
//public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
//{
//    // Confirm parent and childName are valid. 
//    if (parent == null)
//    {
//        return null;
//    }

//    T foundChild = null;

//    var childrenCount = VisualTreeHelper.GetChildrenCount(parent);

//    for (var i = 0; i < childrenCount; i++)
//    {
//        var child = VisualTreeHelper.GetChild(parent, i);

//        // If the child is not of the request child type child
//        T childType = child as T;

//        if (childType == null)
//        {
//            // recursively drill down the tree
//            foundChild = FindChild<T>(child, childName);

//            // If the child is found, break so we do not overwrite the found child. 
//            if (foundChild != null) break;
//        }
//        else
//        {
//            if (!string.IsNullOrEmpty(childName))
//            {
//                var frameworkElement = child as FrameworkElement;

//                // If the child's name is set for search
//                if (frameworkElement != null && frameworkElement.Name == childName)
//                {
//                    // if the child's name is of the request name
//                    foundChild = (T)child;
//                    break;
//                }
//            }
//            else
//            {
//                // child element found.
//                foundChild = (T)child;
//                break;
//            }
//        }
//    }

//    return foundChild;
//}