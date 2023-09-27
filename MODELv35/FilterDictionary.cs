using System;
using System.Collections.Generic;
using System.Data;


namespace Model
{
    public class FilterDictionary : Dictionary<string, FilterParameter>
    {



        public void Add(string fieldname, string HeaderCaption, string Condition, object Value1, object Value2, bool IsGrouped, DbType DbType, Type type, string Operator, bool HasColumn, int index, bool hassqlparameter, string tooltip,int tag=-1)
        {
            FilterParameter val = new FilterParameter();

            val.HeaderCaption = HeaderCaption;
            val.Condition = Condition;
            val.Value1 = Value1;
            val.Value2 = Value2;
            val.IsGrouped = IsGrouped;
            val.DbType = DbType;
            val.Type = type;
            val.Operator = Operator;
            val.HasColumn = HasColumn;
            val.index = index;
            val.HasSqlParameter = hassqlparameter;
            val.ToolTip = tooltip;
            val.Tag = tag;
            this.Add(fieldname, val);

        }

        public FilterParameter Clear(FilterParameter parameter)
        {


            parameter.Condition = "";
            parameter.Value1 = null;
            parameter.Value2 = null;
            parameter.IsGrouped = false;
            parameter.ToolTip = "";
            return parameter;

        }
        public string[] DictionaryToString(FilterDictionary filterdictionary)
        {

            string[] strfiltrelist = new string[2];
            strfiltrelist[0] = "";
            strfiltrelist[1] = "";

            foreach (KeyValuePair<string, FilterParameter> filter in filterdictionary)
            {

                if (filter.Value.Condition != "")
                {

                    if (filter.Value.IsGrouped)
                    {

                        // + "param" + filter.Value.index ;
                        strfiltrelist[1] = strfiltrelist[1] + filter.Value.Operator + filter.Value.Condition;

                    }
                    else
                    {
                        //  + "param" + filter.Value.index;
                        strfiltrelist[0] = strfiltrelist[0] + filter.Value.Operator + filter.Value.Condition;


                    }
                }

            }


            //if (strfiltrelist[0] == "and")
            //{
            //    strfiltrelist[0] = "";
            //}
            //else
            //{
            //    strfiltrelist[0] = strfiltrelist[0].Remove(strfiltrelist[0].Count() - 3, 3);
            //}
            //if (strfiltrelist[1] == "and")
            //{
            //    strfiltrelist[1] = "";
            //}
            //else
            //{
            //    strfiltrelist[1] = strfiltrelist[1].Remove(strfiltrelist[1].Count() - 3, 3);
            //}



            return strfiltrelist;
        }
        public FilterParameter Modify(FilterParameter parameter, string Condition, object Value1, object Value2, bool IsGrouped, DbType DbType)
        {



            //filter.Value.Condition = Condition;
            //filter.Value.Value1 = Value1;
            //filter.Value.Value2 = Value2;
            //filter.Value.IsGrouped = IsGrouped;
            //filter.Value.DbType = DbType;
            //filter.Value.Operator = Operator;

            parameter.Condition = Condition;
            parameter.Value1 = Value1;
            parameter.Value2 = Value2;
            parameter.IsGrouped = IsGrouped;
            parameter.DbType = DbType;
            // parameter.Operator = Operator;
            //  parameter.HasSqlParameter = HasSqlParameter;
            //  parameter.ToolTip = tooltip;
            return parameter;
        }


    }
    public class FilterParameter
    {


        public string HeaderCaption;
        public string Condition;
        public object Value1;
        public object Value2;
        public bool IsGrouped;
        public DbType DbType;//bit,smalldate
        public Type Type;//string, int
        public string Operator;//And Or
        public bool HasColumn;//And Or
        public bool HasSqlParameter;
        public bool FixedParameter;
        public string ToolTip;
        public int index;
        public int Tag;
    }

}
