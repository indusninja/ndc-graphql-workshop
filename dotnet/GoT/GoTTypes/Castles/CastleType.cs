using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT.GoTTypes.Castles
{
    public class CastleType : ObjectGraphType<Castle>
    {
        public CastleType(GoTData data)
        {
            Name = "Castle";

            Field(h => h.Id);
            Field(h => h.Name, nullable: true);
            Field(h => h.Location, nullable: true);
            Field(h => h.Religion, nullable: true);
            /* Field<ListGraphType<string>>(
                "religion",
                resolve: context => data.GetReligions(context.Source)
            ); */
        }
    }
}