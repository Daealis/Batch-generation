using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_generation
{
    public partial class Form1 : Form
    {
        #region Inits and variables
        Boolean batchChanged;
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        static String currentFileName = "";
        static String currentBatchFileName = "";
        List<string> labels = new List<string>();
        List<string> variables = new List<string>();

        System.Data.DataTable batchTable = new DataTable("Batch-file");

        public Form1()
        {
            InitializeComponent();
            batchTable.Columns.Add("Code1");
            batchTable.Columns.Add("Arguments1");
            batchTable.Columns.Add("Code2");
            batchTable.Columns.Add("Arguments2");
            batchTable.Columns.Add("Code3");
            batchTable.Columns.Add("Arguments3");
            Tree_init();
            batchChanged = false;
        }

        private void Form1_FormClose(Object sender, FormClosingEventArgs e)
        {
            if (batchChanged)
            {
                DialogResult answer = MessageBox.Show("The file has been changed.\n Would you like to save it before continuing?", "File Not Saved", MessageBoxButtons.YesNoCancel);
                if (answer == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (answer == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void Tree_init()
        {
            treeView.Nodes.Clear();
            treeView.LabelEdit = true;
            treeView.AllowDrop = true;
            treeView.Nodes.Add(new TreeNode("Untitled Batch-file"));
            treeView.ExpandAll();
        }
        //Collect all label names from the file
        private void Label_init()
        {
            labels.Clear();
            foreach (DataRow row in batchTable.Rows)
            {
                if (row.Field<string>(0) == ":")
                {
                    labels.Add(row.Field<string>(1));
                }
            }

        }
        //Collect all variable names
        private void Variable_init()
        {
            variables.Clear();
            foreach (DataRow row in batchTable.Rows)
            {
                if (row.Field<string>(0) == "@set " || row.Field<string>(0) == "@set /p ")
                {
                    variables.Add(row.Field<string>(1));
                }
            }

        }

        private void treeView_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

            updateStatusStrip(treeView.SelectedNode.Text);
        }

        //When you select a row in the batch file, show the row in statusstrip
        private void updateStatusStrip(string status)
        {
            if (treeView.SelectedNode != null)
            {
                textStatusBarLabel.Text = treeView.SelectedNode.Text;
                statusStrip1.Invalidate();
                statusStrip1.Refresh();
            }
        }

        #endregion
        #region Filemenu buttons and their equivalents in the toolstrip

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Create a new file, destroying anything currently in the editor
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tree_init();
            currentBatchFileName = "";
            currentFileName = "";
            batchTable.Clear();
            richTextBox1.Clear();
            batchChanged = false;
            updateStatusStrip("New File successfully created");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Text Files|*.txt|All Files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFileName = ofd.FileName;
                System.IO.StreamReader sr = new System.IO.StreamReader(currentFileName, Encoding.Default, true);
                batchTable.ReadXml(sr);
                sr.Close();

                treeView.BeginUpdate();
                currentBatchFileName = ofd.FileName;
                foreach (DataRow row in batchTable.Rows)
                {
                    treeView.Nodes[0].Nodes.Add(row.Field<string>(0) + row.Field<string>(1) + row.Field<string>(2) + row.Field<string>(3) + row.Field<string>(4) + row.Field<string>(5));
                }
                treeView.TopNode.Text = Path.GetFileName(currentBatchFileName);
                treeView.EndUpdate();
                treeView.ExpandAll();
                batchChanged = false;
                updateStatusStrip("Projectfile " + Path.GetFileNameWithoutExtension(currentFileName) + " successfully loaded.");
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(currentFileName))
            {
                sfd.Filter = "Text Files|*.txt|All Files|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentFileName = sfd.FileName;
                }
            }
            if (!(String.IsNullOrEmpty(currentFileName)))
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                            new FileStream(currentFileName, FileMode.Create, FileAccess.ReadWrite), Encoding.Default);
                batchTable.WriteXml(sw);
                sw.Close();
                batchChanged = false;
                updateStatusStrip("Projectfile " + Path.GetFileNameWithoutExtension(currentFileName) + " successfully saved.");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Text Files|*.txt|All Files|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentFileName = sfd.FileName;
            }
            saveToolStripMenuItem_Click(sender, e);
        }

        #endregion
        #region Export and Build buttons

        private void exportBatch_Click(object sender, EventArgs e)
        {
            DialogResult loota = new DialogResult();
            string rows = "";

            if (richTextBox1.TextLength > 0)
            {
                query_build buildit = new query_build();
                loota = buildit.ShowDialog();
            }
            if (loota != DialogResult.Cancel)
            {
                sfd.Filter = "Batch Files|*.bat|All Files|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentBatchFileName = sfd.FileName;
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    new FileStream(currentBatchFileName, FileMode.Create, FileAccess.ReadWrite), Encoding.Default);

                    //If "save from richtextbox" is chosen
                    if (loota == DialogResult.Retry)
                    {
                        rows = richTextBox1.Text;
                        sw.Write(rows);
                    }
                    else
                    {
                        foreach (DataRow row in batchTable.Rows)
                        {
                            rows = row.Field<string>(0) + row.Field<string>(1) + row.Field<string>(2) + row.Field<string>(3) + row.Field<string>(4) + row.Field<string>(5);
                            rows += Environment.NewLine;
                            sw.Write(rows);
                        }

                    }
                    sw.Close();
                    treeView.BeginUpdate();
                    treeView.TopNode.Text = Path.GetFileName(currentBatchFileName);
                    treeView.EndUpdate();
                }
            }
            //            MessageBox.Show("Export was a success.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            string line = "";
            foreach (DataRow row in batchTable.Rows)
            {
                line += row.Field<string>(0) + row.Field<string>(1) + row.Field<string>(2) + row.Field<string>(3) + row.Field<string>(4) + row.Field<string>(5);
                line += Environment.NewLine;
            }
            richTextBox1.Text = line;
        }

        #endregion
        #region Batch component buttons
        #region Echo
        private void echoButton_Click(object sender, EventArgs e)
        {
            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }


            //echo-statement related code
            echo_parameters echo = new echo_parameters();

            if (echo.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                DataRow echoRow = batchTable.NewRow();
                if (echo.Arguments != "")
                {
                    string arguments = echo.Arguments;
                    echoRow[0] = "@echo ";
                    echoRow[1] = arguments;

                }
                else
                {
                    echoRow[0] = "@echo.";
                    echoRow[1] = "";

                }
                if (echo.FileWrite)
                {
                    if (!echo.FileAppend)
                        echoRow[2] = ">";
                    else
                        echoRow[2] = ">>";
                    echoRow[3] = echo.FileName;
                }

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(echoRow);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(echoRow, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(echoRow, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, echoRow.Field<string>(0) + echoRow.Field<string>(1) + echoRow.Field<string>(2) + echoRow.Field<string>(3));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

            }
        }
        #endregion

        #region Echo with multiple lines
        private void multilineEchoButton_Click(object sender, EventArgs e)
        {

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_multiEcho mEQuery = new query_multiEcho();

            if (mEQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                bool firstLine = true;
                foreach (string line in mEQuery.getText.Lines)
                {
                    treeView.BeginUpdate();
                    DataRow Row = batchTable.NewRow();
                    Row[0] = "@echo ";
                    Row[1] = line;

                    if (mEQuery.FileWrite)
                    {
                        if (!mEQuery.FileAppend && firstLine)
                        {
                            Row[2] = ">";
                            firstLine = false;
                        }
                        else
                        {
                            Row[2] = ">>";
                        }
                        Row[3] = mEQuery.FileName;
                    }

                    //Insert the line to the desired location
                    if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                    {
                        batchTable.Rows.Add(Row);
                    }

                    else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                    {
                        insertIndex += 1;
                        batchTable.Rows.InsertAt(Row, insertIndex);
                    }

                    else
                    {
                        batchTable.Rows.InsertAt(Row, insertIndex);
                    }

                    treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1) + Row.Field<string>(2) + Row.Field<string>(3));
                    treeView.EndUpdate();

                    insertIndex++;
                }
                insertIndex -= 1;
                //Update the treeview with the information
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }
        }
        #endregion

        #region CLS
        private void clsButton_Click(object sender, EventArgs e)
        {
            batchChanged = true;
            DataRow Row = batchTable.NewRow();
            Row[0] = "@cls";
            Row[1] = "";

            //Get the index which to add the line

            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }


            //Insert the line to the desired location
            if (insertIndex >= treeView.Nodes[0].Nodes.Count)
            {
                batchTable.Rows.Add(Row);
            }

            else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
            {
                insertIndex += 1;
                batchTable.Rows.InsertAt(Row, insertIndex);
            }

            else
            {
                batchTable.Rows.InsertAt(Row, insertIndex);
            }

            //Update the treeview with the information
            treeView.BeginUpdate();
            treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
            treeView.EndUpdate();
            treeView.ExpandAll();
            treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

        }
        #endregion

        #region Label
        private void labelButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = ":";
            Row[1] = "";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            query_label labelquery = new query_label();
            if (labelquery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                Row[1] = labelquery.labelText;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

                //Gather all the labels in our batch to be sent to query_goto
                Label_init();
            }
        }
        #endregion

        #region Goto
        private void gotoButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@goto ";
            Row[1] = "";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            query_goto gotoquery = new query_goto(labels);

            if (gotoquery.ShowDialog() == DialogResult.OK)
            {

                batchChanged = true;
                Row[1] = gotoquery.gotoText;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }
        }
        #endregion

        #region Variable
        private void variableButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@set ";
            Row[2] = " = ";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_var variableQuery = new query_var();

            if (variableQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                Row[1] = variableQuery.varName;
                Row[3] = variableQuery.varValue;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1) + Row.Field<string>(2) + Row.Field<string>(3));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

                Variable_init();
            }
        }
        #endregion

        #region Variable asked from user
        private void varUserButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@set /p ";
            Row[2] = "=";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_userVar variableQuery = new query_userVar();

            if (variableQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                Row[1] = variableQuery.varName;
                Row[3] = variableQuery.varQuery;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1) + Row.Field<string>(2) + Row.Field<string>(3));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

                Variable_init();
            }
        }
        #endregion

        #region If statements
        private void ifButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@if %";
            Row[2] = "% == ";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_if ifQuery = new query_if(labels, variables);

            if (ifQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                Row[1] = ifQuery.varName;
                Row[3] = ifQuery.varCompareTo;
                Row[4] = " " + ifQuery.reactionS + " ";
                Row[5] = ifQuery.reactionLabelS;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1) + Row.Field<string>(2) + Row.Field<string>(3) + Row.Field<string>(4) + Row.Field<string>(5));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

            }

        }
        #endregion

        #region Errorlevels
        private void errorlevelButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@set ";
            Row[1] = "=";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_label labelquery = new query_label();

            if (labelquery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                //Row[1]=varName+Row[1]+varValue;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];

            }

        }
        #endregion

        #region Delete line
        private void removeButton_Click(object sender, EventArgs e)
        {
            //Get the index which to add the line
            if (treeView.SelectedNode != null && treeView.SelectedNode.Parent != null)
            {
                batchChanged = true;
                int insertIndex = treeView.SelectedNode.Index;
                batchTable.Rows.RemoveAt(insertIndex);

                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.RemoveAt(insertIndex);
                treeView.EndUpdate();
                treeView.ExpandAll();

            }

        }
        #endregion

        #region Rem -commenting
        private void remButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@rem ";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_rem remQuery = new query_rem();

            if (remQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                Row[1] = remQuery.Comment;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }
        }
        #endregion

        #region For-loops
        private void forButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@set ";
            Row[1] = "=";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_label labelquery = new query_label();

            if (labelquery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                //Row[1]=varName+Row[1]+varValue;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }
        }
        #endregion

        #region Color commands
        private void colorButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();
            Row[0] = "@color ";

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_color colorQuery = new query_color();

            if (colorQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                Row[1] = colorQuery.BGColor + colorQuery.TColor;

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }
        }
        #endregion

        #region Pause
        private void pauseButton_Click(object sender, EventArgs e)
        {
            DataRow Row = batchTable.NewRow();

            //Get the index which to add the line
            int insertIndex = 0;
            if (treeView.SelectedNode == null)
            {
                insertIndex = 0;
            }
            else
            {
                insertIndex = treeView.SelectedNode.Index;

                if (treeView.SelectedNode.Index > 0)
                {
                    insertIndex += 1;
                }
            }

            //Create the query class and show dialog
            query_pause pauseQuery = new query_pause();

            if (pauseQuery.ShowDialog() == DialogResult.OK)
            {
                batchChanged = true;
                //Variable needs to have two values for fetching
                //variable name and the value
                if (pauseQuery.PauseOrSleep)
                {
                    Row[0] = "@PAUSE ";
                    if (pauseQuery.HidePause)
                        Row[2] = ">nul";
                }
                else
                {
                    Row[0] = "@PING -n ";
                    Row[1] = pauseQuery.SleepTime + 1;
                    Row[2] = " 127.0.0.1>nul";
                }

                //Insert the line to the desired location
                if (insertIndex >= treeView.Nodes[0].Nodes.Count)
                {
                    batchTable.Rows.Add(Row);
                }

                else if (insertIndex == 0 && treeView.SelectedNode.Parent != null)
                {
                    insertIndex += 1;
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                else
                {
                    batchTable.Rows.InsertAt(Row, insertIndex);
                }

                //Update the treeview with the information
                treeView.BeginUpdate();
                treeView.Nodes[0].Nodes.Insert(insertIndex, Row.Field<string>(0) + Row.Field<string>(1) + Row.Field<string>(2));
                treeView.EndUpdate();
                treeView.ExpandAll();
                treeView.SelectedNode = treeView.Nodes[0].Nodes[insertIndex];
            }

        }
        #endregion

        #endregion

    }
}
