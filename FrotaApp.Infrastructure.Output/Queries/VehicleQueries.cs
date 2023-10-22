using FrotaApp.Infrastructure.Shared.Shared;

namespace FrotaApp.Infrastructure.Output.Queries
{
    public class VehicleQueries : BaseQuery
    {
        public QueryModel GetAllVehicles()
        {
            this.Table = Map.GetVehicleTable();
            this.InnerTable = Map.GetVehicleCategoryTable();

            this.Query = $@"
            SELECT V.[ID], V.[CL_NAME] AS [NAME], [CL_COLOR] AS [COLOR], [CL_MODEL_YEAR] AS [MODELYEAR], [CL_CATEGORY_ID] AS [CATEGORYID], [CL_PRICE] AS [PRICE],
            [CL_TYPE] AS [TYPE], C.CL_NAME AS [CATEGORYNAME], V.[CL_CREATED_ON] AS [CREATEDON]
            FROM {this.Table} AS V
            INNER JOIN {this.InnerTable} AS C
            ON V.[CL_CATEGORY_ID] = C.[ID]";

            return new QueryModel(this.Query, null);
        }

        public QueryModel GetVehicleById(int id)
        {
            this.Table = Map.GetVehicleTable();
            this.InnerTable = Map.GetVehicleCategoryTable();

            this.Query = $@"
            SELECT V.[ID], V.[CL_NAME] AS [NAME], [CL_COLOR] AS [COLOR], [CL_MODEL_YEAR] AS [MODELYEAR], [CL_CATEGORY_ID] AS [CATEGORYID], [CL_PRICE] AS [PRICE],
            [CL_TYPE] AS [TYPE], C.CL_NAME AS [CATEGORYNAME], V.[CL_CREATED_ON] AS [CREATEDON]
            FROM {this.Table} AS V
            INNER JOIN {this.InnerTable} AS C
            ON V.[CL_CATEGORY_ID] = C.[ID]
            WHERE V.ID = @VehicleId";

            this.Parameters = new
            {
                VehicleId = id
            };

            return new QueryModel(this.Query, this.Parameters);
        }

        public QueryModel GetVehiclesByCategoryId(int categoryId)
        {
            this.Table = Map.GetVehicleTable();
            this.InnerTable = Map.GetVehicleCategoryTable();

            this.Query = $@"
            SELECT V.[ID], V.[CL_NAME] AS [NAME], [CL_COLOR] AS [COLOR], [CL_MODEL_YEAR] AS [MODELYEAR], [CL_CATEGORY_ID] AS [CATEGORYID], [CL_PRICE] AS [PRICE],
            [CL_TYPE] AS [TYPE], C.CL_NAME AS [CATEGORYNAME], V.[CL_CREATED_ON] AS [CREATEDON]
            FROM {this.Table} AS V
            INNER JOIN {this.InnerTable} AS C
            ON V.[CL_CATEGORY_ID] = C.[ID]
            WHERE V.[CL_CATEGORY_ID] = @CategoryId";

            this.Parameters = new
            {
                CategoryId = categoryId
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
