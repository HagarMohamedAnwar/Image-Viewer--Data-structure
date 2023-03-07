namespace test
{
    public partial class Form1 : Form
    {
        private Queue<Image> cqueue = new Queue<Image>();
        String imgLocation;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnBefore_Click(object sender, EventArgs e)
        {
            try
            {
                Stack<Image> stack = new Stack<Image>();
                Queue<Image> tempQueue = new Queue<Image>(cqueue);

                while (cqueue.Count > 0)
                {
                    stack.Push(cqueue.Dequeue());
                }
                cqueue.Enqueue(stack.Pop());
                stack.Clear();
                while (cqueue.Peek() != tempQueue.Peek())
                {
                    cqueue.Enqueue(tempQueue.Dequeue());
                }
                tempQueue.Clear();
                view.Image = cqueue.Peek();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Empty Gallery", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                Image temp;
                temp = cqueue.Dequeue();
                cqueue.Enqueue(temp);
                view.Image = cqueue.Peek();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Empty Gallery","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                cqueue.Dequeue();
                view.Image = cqueue.Peek();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (String imgLocation in dialog.FileNames)
                {
                    try
                    {
                        cqueue.Enqueue(Image.FromFile(imgLocation));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                try
                {
                    view.Image = cqueue.Peek();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}