namespace E_Players.Models
{
    public class EplayersBase
    {
        public void CreateFolderAndFiler (string _path)
        {
            //Database/equipe.csv
            string folder   = _path.Split("/")[0];
            
            if (Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(_path))
            {
                File.Create(_path);
            }
        }
        
        
    }
}