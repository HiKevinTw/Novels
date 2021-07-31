namespace Novels.Machine.ViewModels
{
    class DataGridColumnAppearance
    {
        public DataGridColumnAppearance(string name, int width)
        {
            this.Name = name;
            this.Width = width;
        }

        public string Name { get; set; }

        public int Width { get; set; }
    }
}
