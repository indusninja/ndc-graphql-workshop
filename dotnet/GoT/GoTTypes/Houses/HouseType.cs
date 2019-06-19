using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT.GoTTypes.Houses
{
    public class HouseType : ObjectGraphType<House>
    {
        public HouseType(GoTData data)
        {
            Name = "House";

            Field(h => h.Id);
            Field(h => h.Name, nullable: true);
            Field(h => h.Words, nullable: true);
            Field(h => h.Region, nullable: true);
            Field(h => h.Image, nullable: true);Field<ListGraphType<HouseType>>(
                "allegionhouse",
                resolve: context => data.GetAllegion(context.Source)
            );
            Field<ListGraphType<CharacterType>>(
                "members",
                resolve: context => data.GetHouseMembers(context.Source)
            );
            /* Field<ListGraphType<string>>(
                "religion",
                resolve: context => data.GetReligions(context.Source)
            ); */
        }
    }
}