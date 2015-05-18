using UnityEngine;
using System.Collections;

public interface AgonistInterface {


	void pauseMovement();
	void Damage(int amount);
	void KnockBack(Vector3 dir);
}
