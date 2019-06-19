using GoT.GoTTypes.Castles;
using GoT.GoTTypes.Character;
using GoT.GoTTypes.Houses;
using GraphQL.Types;

namespace GoT
{
    public class GotQuery : ObjectGraphType<object>
    {
        public GotQuery(GoTData data)
        {  
            Name = "Query";

            Field<ListGraphType<CharacterType>>("characters", resolve: context => data.GetCharacters());

            Field<ListGraphType<HouseType>>("houses", resolve: context => data.GetHouses());

            Field<ListGraphType<CastleType>>("castles", resolve: context => data.GetCastles());

            Field<CharacterType>(
            "character",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "name", Description = "name of the character" }
            ),
            resolve: context =>
            {
                var name = context.GetArgument<string>("name");
                return data.GetCharacter(name);
            });
        }
    }
}