using System.Collections;

public interface ITargetable {

	float Health {get; set;}

	void TakeHit(float damage);
}
