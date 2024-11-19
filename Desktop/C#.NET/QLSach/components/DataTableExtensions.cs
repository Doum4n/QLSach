using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using MoreLinq;

public static class DataTableExtensions
{
    public static DataTable ToFilteredDataTable<T>(this IEnumerable<T> data)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);

        // Lấy tất cả các thuộc tính công khai của T
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Lọc các thuộc tính bị đánh dấu [Browsable(false)] và chỉ thêm các thuộc tính hiển thị
        List<PropertyInfo> visibleProps = new List<PropertyInfo>();
        foreach (PropertyInfo prop in Props)
        {
            var browsableAttribute = prop.GetCustomAttribute<BrowsableAttribute>();

            // Nếu không có thuộc tính BrowsableAttribute hoặc bị đánh dấu là Browsable(true)
            if (browsableAttribute == null || browsableAttribute.Browsable)
            {
                dataTable.Columns.Add(prop.Name); // Thêm cột vào DataTable
                visibleProps.Add(prop); // Lưu lại các thuộc tính hiển thị
            }
        }

        // Lặp qua các đối tượng và thêm các giá trị vào DataTable
        foreach (T item in data)
        {
            List<object> values = new List<object>();

            foreach (PropertyInfo prop in visibleProps)
            {
                // Lấy giá trị của thuộc tính không bị đánh dấu [Browsable(false)]
                values.Add(prop.GetValue(item, null));
            }

            // Thêm giá trị vào DataTable
            dataTable.Rows.Add(values.ToArray());
        }

        return dataTable;
    }
}
