using UnityEngine;

public interface IGoal {

	Vector3 destination { get; }
	bool AtDestination();
}
