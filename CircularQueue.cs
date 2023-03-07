namespace test
{
    class CircularQueue
    {
        private Image[] images;
        private int front;
        private int rear;
        private int size;
        private int count;
        int i;

        public CircularQueue(int size)
        {
            images = new Image[size];
            front = 0;
            i = front;
            rear = -1;
            this.size = size;
            count = 0;
        }

        public void Enqueue(Image image)
        {
            if (count == size)
            {
                throw new Exception("Circular Queue is Full");
            }
            else
            {
                rear = (rear + 1) % size;
                images[rear] = image;

                count++;
            }
        }

        public void Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("Queue is Empty");
            }
            else
            {
                Console.WriteLine("deleted element is: " + images[front]);

                front = (front + 1) % size;

                count--;
            }
        }

        public Image Peek()
        {
            i = front;
            if (front != -1 && rear != -1 && front <= rear)
            {
                return images[front];
            }
            else
            {
                MessageBox.Show("Gallery is empty, Add Files first", "Error", MessageBoxButtons.OK);
                return null;
            }

        }

        public Image next()
        {
            if (images[front] == null)
                throw new Exception("Empty Gallery");
            i = (i + 1) % size;
            while (images[i] == null)
            {
                i = (i + 1) % size;
            }
            return images[i];
        }
    }
}
