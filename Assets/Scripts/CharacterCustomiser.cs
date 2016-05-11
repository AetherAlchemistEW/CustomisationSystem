using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterCustomiser : MonoBehaviour 
{
	public enum Bases
	{
		Big,
		Small
	};
	private Bases currentBase;

	public enum Slots
	{
		Helm,
		ShoulderL,
		ShoulderR,
		Chest,
		GlovesL,
		GlovesR,
		LegsL,
		LegsR,
		BootsL,
		BootsR
	};
	private Slots currentSlot;

	public GameObject[] baseMeshesRef;
	public GameObject[] baseMeshesNode;
	private GameObject baseMesh;
	private int baseIndex = 0;

	//mesh, type, item.
	private GameObject[,][] gear;
	private GameObject[] gearInst;
	private int[,] gearIndex;
	private Vector4[,] gearTint;

	private Transform cam;

	public Canvas[] Uis;
	private Canvas currentUI;

	public GameObject[] test;

	// Update is called once per frame
	void Start () 
	{
		currentUI = Uis [0];
		currentUI.enabled = true;
		cam = Camera.main.transform;
		LoadUp ();
	}

	//Load in all the resources.
	void LoadUp()
	{
		//Set up all my arrays
		gear = new GameObject[baseMeshesRef.Length, baseMeshesNode.Length][];
		gearIndex = new int[baseMeshesRef.Length,  baseMeshesNode.Length];
		gearTint = new Vector4[baseMeshesRef.Length,  baseMeshesNode.Length];
		gearInst = new GameObject[baseMeshesNode.Length];

		/*for(int i = 0; i < baseMeshesRef.Length; i++)
		{
			for(int j = 0; j < baseMeshesNode.Length; j++)
			{
				Debug.Log((Bases)i + " " + (Slots)j);
				gear [i,j] = new GameObject[Resources.LoadAll<GameObject> ((Bases)i + " " + (Slots)j).Length];
				gear [i,j] = Resources.LoadAll<GameObject> ((Bases)i + " " + (Slots)j);
				gearIndex [i,j] = 0;
				gearTint [i,j] = new Vector4(1,1,1,1);
			}
		}
		*/

		//Base mesh one
		gear [(int)Bases.Big, (int)Slots.Helm] = new GameObject[Resources.LoadAll<GameObject> (Bases.Big + "/Helm").Length];
		gear[(int)Bases.Big,(int)Slots.Helm] = Resources.LoadAll<GameObject> (Bases.Big + "/Helm");
		gearIndex [(int)Bases.Big, (int)Slots.Helm] = 0;
		gearTint [(int)Bases.Big, (int)Slots.Helm] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.ShoulderL] = Resources.LoadAll<GameObject> (Bases.Big + "/Shoulder");
		gearIndex [(int)Bases.Big, (int)Slots.ShoulderL] = 0;
		gearTint [(int)Bases.Big, (int)Slots.ShoulderL] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.ShoulderR] = Resources.LoadAll<GameObject> ("Big/Shoulder");
		gearIndex [(int)Bases.Big, (int)Slots.ShoulderR] = 0;
		gearTint [(int)Bases.Big, (int)Slots.ShoulderR] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.Chest] = Resources.LoadAll<GameObject> ("Big/Chest");
		gearIndex [(int)Bases.Big, (int)Slots.Chest] = 0;
		gearTint [(int)Bases.Big, (int)Slots.Chest] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.GlovesL] = Resources.LoadAll<GameObject> ("Big/Gloves");
		gearIndex [(int)Bases.Big, (int)Slots.GlovesL] = 0;
		gearTint [(int)Bases.Big, (int)Slots.GlovesL] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.GlovesR] = Resources.LoadAll<GameObject> ("Big/Gloves");
		gearIndex [(int)Bases.Big, (int)Slots.GlovesR] = 0;
		gearTint [(int)Bases.Big, (int)Slots.GlovesR] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.LegsL] = Resources.LoadAll<GameObject> ("Big/Legs");
		gearIndex [(int)Bases.Big, (int)Slots.LegsL] = 0;
		gearTint [(int)Bases.Big, (int)Slots.LegsL] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.LegsR] = Resources.LoadAll<GameObject> ("Big/Legs");
		gearIndex [(int)Bases.Big, (int)Slots.LegsR] = 0;
		gearTint [(int)Bases.Big, (int)Slots.LegsR] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.BootsL] = Resources.LoadAll<GameObject> ("Big/Boots");
		gearIndex [(int)Bases.Big, (int)Slots.BootsL] = 0;
		gearTint [(int)Bases.Big, (int)Slots.BootsL] = new Vector4(1,1,1,1);

		gear[(int)Bases.Big,(int)Slots.BootsR] = Resources.LoadAll<GameObject> ("Big/Boots");
		gearIndex [(int)Bases.Big, (int)Slots.BootsR] = 0;
		gearTint [(int)Bases.Big, (int)Slots.BootsR] = new Vector4(1,1,1,1);

		//Base mesh two
		gear [(int)Bases.Small, (int)Slots.Helm] = new GameObject[Resources.LoadAll<GameObject> ("Small/Helm").Length];
		gear[(int)Bases.Small,(int)Slots.Helm] = Resources.LoadAll<GameObject> ("Small/Helm");
		gearIndex [(int)Bases.Small, (int)Slots.Helm] = 0;
		gearTint [(int)Bases.Small, (int)Slots.Helm] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.ShoulderL] = Resources.LoadAll<GameObject> ("Small/Shoulder");
		gearIndex [(int)Bases.Small, (int)Slots.ShoulderL] = 0;
		gearTint [(int)Bases.Small, (int)Slots.ShoulderL] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.ShoulderR] = Resources.LoadAll<GameObject> ("Small/Shoulder");
		gearIndex [(int)Bases.Small, (int)Slots.ShoulderR] = 0;
		gearTint [(int)Bases.Small, (int)Slots.ShoulderR] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.Chest] = Resources.LoadAll<GameObject> ("Small/Chest");
		gearIndex [(int)Bases.Small, (int)Slots.Chest] = 0;
		gearTint [(int)Bases.Small, (int)Slots.Chest] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.GlovesL] = Resources.LoadAll<GameObject> ("Small/Gloves");
		gearIndex [(int)Bases.Small, (int)Slots.GlovesL] = 0;
		gearTint [(int)Bases.Small, (int)Slots.GlovesL] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.GlovesR] = Resources.LoadAll<GameObject> ("Small/Gloves");
		gearIndex [(int)Bases.Small, (int)Slots.GlovesR] = 0;
		gearTint [(int)Bases.Small, (int)Slots.GlovesR] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.LegsL] = Resources.LoadAll<GameObject> ("Small/Legs");
		gearIndex [(int)Bases.Small, (int)Slots.LegsL] = 0;
		gearTint [(int)Bases.Small, (int)Slots.LegsL] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.LegsR] = Resources.LoadAll<GameObject> ("Small/Legs");
		gearIndex [(int)Bases.Small, (int)Slots.LegsR] = 0;
		gearTint [(int)Bases.Small, (int)Slots.LegsR] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.BootsL] = Resources.LoadAll<GameObject> ("Small/Boots");
		gearIndex [(int)Bases.Small, (int)Slots.BootsL] = 0;
		gearTint [(int)Bases.Small, (int)Slots.BootsL] = new Vector4(1,1,1,1);
		
		gear[(int)Bases.Small,(int)Slots.BootsR] = Resources.LoadAll<GameObject> ("Small/Boots");
		gearIndex [(int)Bases.Small, (int)Slots.BootsR] = 0;
		gearTint [(int)Bases.Small, (int)Slots.BootsR] = new Vector4(1,1,1,1);


		//Move on to loading up the default state
		SetBase ();
	}

	//Change the base character mesh
	void SetBase()
	{
		//Destroy current base,
		if(baseMesh != null)
		{
			Destroy(baseMesh);
			baseMesh = (GameObject)Instantiate(baseMeshesRef[baseIndex], transform.position, Quaternion.identity);
			baseMeshesNode = baseMesh.GetComponent<Character>().nodes;
		}
		else
		{
			baseMesh = (GameObject)Instantiate(baseMeshesRef[baseIndex], transform.position, Quaternion.identity);
			baseMeshesNode = baseMesh.GetComponent<Character>().nodes;
		}
		//Instantiate new one based on passed index
		//Set Gear based on GearIndex

		for(int i=0; i< baseMeshesNode.Length; i++)
		{
			//Debug.Log(i + " " + (Bases)baseIndex + " " + (Slots)i + " " + gear[baseIndex,i][gearIndex[baseIndex,i]].name);
			//Debug.Log(i + " " + (Bases)baseIndex + " " + (Slots)i + " " + gearIndex[baseIndex,i][i]);

			SetGear(i, gear[baseIndex,i][gearIndex[baseIndex,i]], baseMeshesNode[i]);
		}
	}

	void OnGUI()
	{
		if(GUILayout.Button("Helm"))
		{
			//Scroll through helms
			//ChangeGear(true, (int)Slots.Helm);
			currentSlot = Slots.Helm;
			PanCamera(baseMeshesNode[(int)Slots.Helm].transform,Uis[((int)Slots.Helm)+1]);
		}
		if(GUILayout.Button("Shoulder"))
		{
			//Scroll through helms
			//ChangeGear(true, (int)Slots.ShoulderL);
			currentSlot = Slots.ShoulderL;
			PanCamera(baseMeshesNode[(int)Slots.ShoulderL].transform,Uis[((int)Slots.ShoulderL)+1]);
		}
		if(GUILayout.Button ("Next Mesh"))
		{
			if(baseIndex < baseMeshesRef.Length-1)
			{
				baseIndex ++;
			}
			else
			{
				baseIndex = 0;
			}
			SetBase();
		}
	}

	//Serves as a controller for the UI
	public void ScrollGearForward()
	{
		ChangeGear (true, (int)currentSlot);
	}
	//Serves as a controller for the UI
	public void ScrollGearBackward()
	{
		ChangeGear (false, (int)currentSlot);
	}

	//Scroll through gear based on UI
	void ChangeGear(bool fwd, int slot)
	{
		for(int i = 0; i < baseMeshesRef.Length-1; i++)
		{
			switch(slot)
			{
				case (int)Slots.Helm:
					if(fwd)//next
					{
						if(gearIndex[i,(int)(Slots.Helm)] < gear[i,(int)(Slots.Helm)].Length-1)
						{
							gearIndex[i,(int)(Slots.Helm)] ++;
						}
						else
						{
							gearIndex[i,(int)(Slots.Helm)] = 0;
						}
						SetGear((int)Slots.Helm, gear[i,(int)Slots.Helm][gearIndex[i,(int)Slots.Helm]], baseMeshesNode[(int)Slots.Helm]);
					}
					else//previous
					{
						if(gearIndex[i,(int)(Slots.Helm)] > 0)
						{
							gearIndex[i,(int)(Slots.Helm)] --;
						}
						else
						{
							gearIndex[i,(int)(Slots.Helm)] = gear[i,(int)(Slots.Helm)].Length-1;
						}
						SetGear((int)Slots.Helm, gear[i,(int)Slots.Helm][gearIndex[i,(int)Slots.Helm]], baseMeshesNode[(int)Slots.Helm]);
					}
				break;
				case (int)Slots.ShoulderL:
					if(fwd)//next
					{
						if(gearIndex[i,(int)(Slots.ShoulderL)] < gear[i,(int)(Slots.ShoulderL)].Length-1)
						{
							gearIndex[i,(int)(Slots.ShoulderL)] ++;
						}
						else
						{
							gearIndex[i,(int)(Slots.ShoulderL)] = 0;
						}
						SetGear((int)Slots.ShoulderL, gear[i,(int)Slots.ShoulderL][gearIndex[i,(int)Slots.ShoulderL]], baseMeshesNode[(int)Slots.ShoulderL]);
					}
					else//previous
					{
						if(gearIndex[i,(int)(Slots.ShoulderL)] > 0)
						{
							gearIndex[i,(int)(Slots.ShoulderL)] --;
						}
						else
						{
							gearIndex[i,(int)(Slots.ShoulderL)] = gear[i,(int)(Slots.ShoulderL)].Length-1;
						}
						SetGear((int)Slots.ShoulderL, gear[i,(int)Slots.ShoulderL][gearIndex[i,(int)Slots.ShoulderL]], baseMeshesNode[(int)Slots.ShoulderL]);
					}
				break;

			}
		}
	}

	void SetGear(int index, GameObject itemRef, GameObject node)
	{
		//Destroy current gear,
		if(gearInst[index] != null)
		{
			Destroy(gearInst[index]);
			gearInst[index] = (GameObject)Instantiate(itemRef, node.transform.position, node.transform.rotation);
		}
		else
		{
			gearInst[index] = (GameObject)Instantiate(itemRef, node.transform.position, node.transform.rotation);
		}
		//Instantiate new gear based on passed index
		//Set colour based on colour index
		for(int i = 0; i < baseMeshesRef.Length-1; i++)
		{
			SetColour (gearInst[index], gearTint[i,index]);
		}
	}

	//For UI Access
	public void ColourPicker(Image pick)
	{
		Color color = pick.color;
		for(int i = 0; i < baseMeshesRef.Length-1;i++)
		{
			gearTint[i, (int)currentSlot] = color;
		}
		SetColour (gearInst [(int)currentSlot], gearTint[baseIndex, (int)currentSlot]);
	}

	void SetColour(GameObject itemInst, Color color)
	{
		//Set material and/or colour
		itemInst.GetComponent<Renderer> ().material.color = color;
	}

	void PanCamera(Transform target, Canvas targetUI)
	{
		currentUI.enabled = false;
		cam.GetComponent<CameraControls> ().StartCoroutine ("PanCamera", target);
		if(!targetUI.enabled)
		{
			targetUI.enabled = true;
			currentUI = targetUI;
		}
	}
}

/*
 * Array of GameObjects for base mesh. Destroy and Instantiate as selected.
Multi-Dimensional Array, first index matches to base mesh index. (multiple arrays for ease of assignment?), can I do a resource call against folder contents?
Meshes have nodes, those nodes refer to placement and are in a matching array on the base mesh. Nodes should be set up in 3DS for animation purposes. Be mindful of their pivot points as well.
Method for base meshes and method for gear, if you change base you run through gear also and set it again.
Array of ints for keeping track of assigned gear.
Array of Vector 4 for keeping track of gear tints.

Instantiate and destroy gear as selected at node position and rotation, then child to the node. Remember to set its colour (and material?) again.

Suit, material
Helmet, mesh
Chestplate, mesh
Shoulder, mesh
Bracer, mesh
Gloves, mesh
Legs, mesh
Boots, mesh

Store slot (or mesh) as enums instead of just indexs.

(Draw array structure out...)

Tint, feeds new Vector4 based on UI into material or material on mesh
UI texture (tinted to stored colour).
When selected opens tint UI which is a larger texture and mouse position feeds into the colour variable while mouse button is down.

UI changes based on assignment, camera positions in transition.

Transition Method. Canvas, Camera position, and Camera target arguments.
Old UI off,
Lerp over,
Constantly set to look at target.
Once lerp is done, turn new UI on (All UI childed to the camera).

Pass important values to a manager on exit,
Server will scroll through joined players and retrieve values then instantiate and set up each player.
*/