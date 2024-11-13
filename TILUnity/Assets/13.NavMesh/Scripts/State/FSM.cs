public abstract class AState<T>
{
	protected T owner;
	
	public AState(T owner)
	{
		this.owner = owner;
	}
	
	public abstract void OnUpdate();
	public abstract void OnEnter();
	public abstract void OnExit();
}

public class FSM<T>
{
	private AState<T> currentState;
	private T owner;
	
	public FSM(T owner)
	{
		this.owner = owner;
	}

	public void Update()
	{
		currentState?.OnUpdate();
	}

	public void TransitionState(AState<T> newState)
	{
		currentState?.OnExit();
		currentState = newState;
		currentState.OnEnter();
	}
}