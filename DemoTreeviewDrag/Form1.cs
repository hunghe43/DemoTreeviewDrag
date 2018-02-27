using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DemoTreeviewDrag
{
    public partial class Form1 : Form
    {
        LoadData load = new LoadData();
        TreeView tree;
        TreeNode nodeKeo;
        TreeNode node;
        TreeNode nodeTha;
        Point point;
        public Form1()
        {
            InitializeComponent();
            TV1.DragDrop += new DragEventHandler(Drop);
            TV1.DragOver += new DragEventHandler(Over);
            TV1.MouseDown += new MouseEventHandler(Down);
            TV1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(NodeDoubleClick);
            //TV1.NodeMouseClick += new TreeNodeMouseClickEventHandler(NodeClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listGeographicalRegion = load.ListGeographicalRegion();
            if (listGeographicalRegion.Count > 0)
            {
                //create node GeographicalRegion
                TreeNode NodeGeographicalRegion;
                foreach (var geographicalRegion in listGeographicalRegion)
                {
                    NodeGeographicalRegion = new TreeNode();
                    NodeGeographicalRegion.Text = geographicalRegion._GeographicalRegionName;
                    NodeGeographicalRegion.Tag = geographicalRegion;
                    NodeGeographicalRegion.Name = geographicalRegion._GeographicalRegionName;

                    TV1.Nodes.Add(NodeGeographicalRegion);
                    //create node SubGeographicalRegions
                    if (geographicalRegion._SubGeographicalRegions.Count > 0)
                    {
                        TreeNode NodeSubGeographicalRegions;
                        foreach (var subGeographicalRegion in geographicalRegion._SubGeographicalRegions)
                        {
                            if (subGeographicalRegion._GeographicalRegionID == geographicalRegion._GeographicalRegionID)
                            {
                                NodeSubGeographicalRegions = new TreeNode();
                                NodeSubGeographicalRegions.Text = subGeographicalRegion._SubGeographicalRegionsID;
                                NodeSubGeographicalRegions.Tag = subGeographicalRegion;

                                NodeSubGeographicalRegions.Name = subGeographicalRegion._SubGeographicalRegionsID;

                                TV1.Nodes[NodeGeographicalRegion.Name].Nodes.Add(NodeSubGeographicalRegions);
                                TreeNode NodeLines;
                                TreeNode NodeSubstations;
                                var nodeLines = TV1.Nodes[NodeGeographicalRegion.Name].Nodes[NodeSubGeographicalRegions.Name].Nodes.Add("Lines");
                                var nodeSubstations = TV1.Nodes[NodeGeographicalRegion.Name].Nodes[NodeSubGeographicalRegions.Name].Nodes.Add("Substations");
                                foreach (var line in subGeographicalRegion._Lines)
                                {
                                    if (line._SubGeographicalRegionsID == subGeographicalRegion._SubGeographicalRegionsID)
                                    {
                                        NodeLines = new TreeNode();
                                        NodeLines.Text = line._LineName;
                                        NodeLines.Tag = line;
                                        NodeLines.Name = line._LineName;

                                        nodeLines.Nodes.Add(NodeLines);
                                        //foreach (var tower in line.ACLineSegments)

                                    }
                                }
                                foreach (var substation in subGeographicalRegion._Substations)
                                {
                                    if (substation._SubGeographicalRegionsID == subGeographicalRegion._SubGeographicalRegionsID)
                                    {
                                        NodeSubstations = new TreeNode();
                                        NodeSubstations.Text = substation._SubstationName;
                                        NodeSubstations.Tag = substation;
                                        NodeSubstations.Name = substation._SubstationName;

                                        nodeSubstations.Nodes.Add(NodeSubstations);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }       

        private void Down(object sender, MouseEventArgs e)
        {
            tree = (TreeView)sender;
            nodeKeo = tree.GetNodeAt(e.X, e.Y);
            tree.SelectedNode = nodeKeo;
            if (nodeKeo != null)
            {
                tree.DoDragDrop(nodeKeo.Clone(), DragDropEffects.Copy);
            }
        }
        private void Over(object sender, DragEventArgs e)
        {
            tree = (TreeView)sender;
            if (e.Data.GetData(typeof(TreeNode)) != null)
            {
                point = new Point(e.X, e.Y);
                point = tree.PointToClient(point);
                nodeTha = tree.GetNodeAt(point);
                if (nodeTha != null)
                {
                    e.Effect = DragDropEffects.Copy;
                    tree.SelectedNode = nodeTha;
                }
            }
        }
        private void Drop(object sender, DragEventArgs e)
        {
            tree = (TreeView)sender;
            if (nodeTha.Level == nodeKeo.Level - 1)
            {
                if (nodeTha != null && !nodeTha.FullPath.Equals(nodeKeo.FullPath))
                {
                    TreeNode nodeTemp = nodeKeo;
                    tree.Nodes.Remove(nodeKeo);
                    nodeTha.Nodes.Add(nodeTemp);
                    nodeTha.Expand();
                }
                else
                {
                    MessageBox.Show("Exitst node!");
                }
            }
            else
            {
                MessageBox.Show("not same Lever!");
            }
        }

        //private void NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    node = ((TreeView)sender).SelectedNode;
        //    point = new Point(MousePosition.X, MousePosition.Y);

        //    Cms.Show(point);
        //}

        private void treeviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TV1.Nodes.Add(Interaction.InputBox("digiter o nome do node: ", "Criano node...", "SkoNode..."));
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            node.Nodes.Add(Interaction.InputBox("digiter o nome do children: ", "Criano children...", "SkoChildren..."));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            node.Remove();
        }

        private void alterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            node.Text = Interaction.InputBox("digite o nome do node: ", "Alter node...", "Text");
        }

        private void NodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            node = ((TreeView)sender).SelectedNode;
            getDataPropertiesNode(node);

        }
        private void getDataPropertiesNode(TreeNode treenode)
        {
            string[] row = new string[] { };
            DataGridViewLinkColumn link = new DataGridViewLinkColumn();
            link.Name = "Path";

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Attributes";
            dataGridView1.Columns[1].Name = "Types";
            dataGridView1.Columns[2].Name = "Values";
            dataGridView1.Columns.Add(link);

            //dataGridView1.Columns[3].Name = "Path";
            dataGridView1.Rows.Clear();

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(treenode.Tag))
            {
                string attribute = descriptor.Name;
                string value = descriptor.GetValue(treenode.Tag).ToString();
                string type = descriptor.PropertyType.ToString().Substring(7);
                string pathParent = "";

                if (treenode.Parent != null)
                {
                    pathParent = treenode.Parent.Text;
                }
                row = new string[] { attribute, type, value, pathParent };
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            node = node.Parent;
            getDataPropertiesNode(node);
        }
    }
}
