using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Wxg.Utils;
using System.Data.Linq;
using System.Collections;


namespace Wxg.UI.Forms
{
    public class TreeDataBinder
    {
        public static void DataBind(TreeView treeView, DataSet dataSource, string rootTableName)
        {
            DataRowCollection rows = dataSource.Tables[rootTableName].Rows;
            AddTreeNode2(treeView.Nodes, dataSource, rows, rootTableName);
        }

        //private static void AddTreeNode(TreeNodeCollection nodes, DataSet dataSource, string parentTableName)
        //{
        //    List<DataRelation> lstRelations = GetRelations(dataSource, parentTableName);
        //    foreach (DataRow row in dataSource.Tables[parentTableName].Rows)
        //    {
        //        TreeNode rootnode = nodes.Add(CollectionUtil.ToString(row));

        //        foreach (DataRelation r in lstRelations)
        //        {
        //            DataRow[] children = row.GetChildRows(r);
                    
        //            AddTreeNode(rootnode.Nodes, dataSource, r.ChildTable.TableName);
        //        }
        //    }
        //}

        private static void AddTreeNode2(TreeNodeCollection nodes, 
                                        DataSet dataSource,
                                        ICollection parentRows, 
                                        string parentTableName)
        {
            List<DataRelation> lstRelations = GetRelations(dataSource, parentTableName);

            foreach (DataRow row in parentRows)
            {
                TreeNode rootnode = nodes.Add(CollectionUtil.ToString(row));

                foreach (DataRelation r in lstRelations)
                {
                    AddTreeNode2(rootnode.Nodes, 
                                dataSource, 
                                row.GetChildRows(r), 
                                r.ChildTable.TableName);
                }
            }
        }








        private static List<DataRelation> GetRelations(DataSet dataSource, string tablename)
        {
            List<DataRelation> thisRelations = new List<DataRelation>();
            foreach (DataRelation r in dataSource.Relations)
            {
                if (r.ParentTable.TableName == tablename)
                {
                    thisRelations.Add(r);
                }
            }
            return thisRelations;
        }
    }
        
}
