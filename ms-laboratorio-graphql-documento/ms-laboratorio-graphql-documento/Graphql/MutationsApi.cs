using GraphQLUtilitiesMicroServices;

namespace ms_laboratorio_graphql_documento.Graphql
{
    public class MutationsApi
    {
        public async Task<ResultModel<bool>> SendFile(IFile file, string fileName, int idLine)
        {
            var result = new ResultModel<bool>();

            try
            {
                string workPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

                using (var stream = File.Create(workPath))
                {
                    await file.CopyToAsync(stream);
                }

                string base64 = Convert.ToBase64String(File.ReadAllBytes(workPath));
                File.Delete(workPath);
            }
            catch (Exception ex)
            {
                result = new ResultModel<bool>(ex);
            }

            return result;
        }
    }
}
