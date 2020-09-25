using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WorldToLocal : MonoBehaviour
{
    public Transform ParentTransform, ChildTransform, WorldTransform;
    public Vector2 LocalToWorldOffset, ChildWorldPosition;
    public Vector2 ParentToWorldVector, ParentToWorldLocalVector, WorldAndLocalMagnitudes;

    public Text LocalToWorldPosition, WorldToLocalPosition;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        FindWorldPosition();
        FindLocalPosition();
    }

    private void FindWorldPosition()
    {
        //To find the world position of the child object, first we have to figure out the
        //offset the Parent Transform has introduced. By multiplying the childs localPosition
        //with the parent's world rotation, we can find this offset
        LocalToWorldOffset = ParentTransform.right * ChildTransform.localPosition.x + ParentTransform.up * ChildTransform.localPosition.y;
        //To get the child's world position, we simply add the offset to the parent's
        //world position! The offset takes care of any rotation the parent might have.
        ChildWorldPosition = new Vector2(ParentTransform.position.x + LocalToWorldOffset.x, ParentTransform.position.y + LocalToWorldOffset.y);
        LocalToWorldPosition.text = $"The Child Object's world coordinates are {ChildWorldPosition.x}, {ChildWorldPosition.y}";
    }

    private void FindLocalPosition()
    {
        //This finds the vector between the "local" point and the tracked point
        ParentToWorldVector = WorldTransform.position - ParentTransform.position;

        //This doesn't take the local positions rotation in consideration.
        //However, with the dot product, we can!
        //Since transform.right and transform.up alway return normalised vectors,
        //we can use them to find where where the Parent to World vector
        //intersects with the Parent.right and Parent.up!
        ParentToWorldLocalVector.x = Vector2.Dot(ParentTransform.right, ParentToWorldVector);
        ParentToWorldLocalVector.y = Vector2.Dot(ParentTransform.up, ParentToWorldVector);
        WorldToLocalPosition.text = $"The World Object's local coordinates are {Mathf.Round(ParentToWorldLocalVector.x)}, {Mathf.Round(ParentToWorldLocalVector.y)}";


        //I made this for myself, if both magnitudes are equal, the I've done it right.
        WorldAndLocalMagnitudes.x = ParentToWorldVector.magnitude;
        WorldAndLocalMagnitudes.y = ParentToWorldLocalVector.magnitude;

        //I wrote all this out to prove to myself that I understood what these things
        //do and that I didn't just blindly follow Freyas instructions. I had to look
        //at the stream and now I feel guilty.

        //Please don't make me hook this up to gizmos, I don't know how they work.
    }

    

#endif
}