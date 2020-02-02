
namespace DbEntities
{
	public interface IStateObject
	{
		State State
		{
			get; set;
		}
	}

	public enum State { Unchanged, Added, Modified, Deleted }

}
