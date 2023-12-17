
using ms_laboratorio_graphql_documento.Graphql;

namespace ms_laboratorio_graphql_documento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                   .AddGraphQLServer()
                   .AddType<UploadType>()
                   .AddQueryType<QuerysApi>()
                   .AddMutationType<MutationsApi>()
                   .AddMutationConventions();           

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.MapGraphQL();

            app.Run();
        }
    }
}