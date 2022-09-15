namespace VisitorManagementStudent2022.Services
{
    public class TextFileOperations : ITextFileOperations
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TextFileOperations(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }



        public IEnumerable<string> LoadConditionsOfAcceptance()
        {

            //get the webroot path
            string webRootPath = _webHostEnvironment.WebRootPath;

            //get teh full path with the filename
            FileInfo filePath = new FileInfo(Path.Combine(webRootPath, "ConditionsForAdmittance.txt"));

            //read out the lines and pass to string array
            string[] lines = System.IO.File.ReadAllLines(filePath.ToString());

            return lines.ToList();


        }


    }
}
