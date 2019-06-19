using GoT.GoTTypes.Character;
using GraphQL.Types;

namespace GoT
{
    public class GotMutation : ObjectGraphType
    {
        public GotMutation(GoTData data)
        {
            Name = "Mutation";

            //FIELDS ARE COMING HERE

            Field<CharacterType>(
            "pushFromWindow",
            arguments: new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "name", Description = "name of the character" }
            ),
            resolve: context =>
            {
                var characterName = context.GetArgument<string>("name");
                return data.PushCharacterFromWindow(characterName);
            });
        }
    }
}