using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine.UI;


public class Start {
	public bool team_1;
	public bool team_2;
	public bool team_3;
	public bool team_4;
}

public class Score {
	public int team_1;
	public int team_2;
	public int team_3;
	public int team_4;
}


public class Item {
	public float position_x;
	public float position_y;
}


public class aaa : MonoBehaviour {

	public MovieTexture stage_1;
	public MovieTexture stage_2;
	public MovieTexture stage_3;

		


	public MovieTexture red_apple;
	public MovieTexture red_suzaku;
	public MovieTexture red_airplane;

	public MovieTexture gre_genbu;
	public MovieTexture gre_frog;
	public MovieTexture gre_flower;

	public MovieTexture yel_tiger;
	public MovieTexture yel_duck;
	public MovieTexture yel_butterfly;

	public MovieTexture blu_dragon;
	public MovieTexture blu_fish;
	public MovieTexture blu_umbrella;


	public GameObject Cube;
	public GameObject Sphere;
	public GameObject Torus;
	public GameObject Pyramid;

	public int model_1_count = 0;
	public int model_2_count = 0;
	public int model_3_count = 0;
	public int model_4_count = 0;

	public int model_1_raw = 0;
	public int model_2_raw = 0;
	public int model_3_raw = 0;
	public int model_4_raw = 0;


	public bool start_check = false;
	public bool end_check = false;

	public float stage_get_speed = 1.0f;

	void Start () {

		GameObject.Find("Cube").GetComponent<Animator> ().enabled = false;
		GameObject.Find("Sphere").GetComponent<Animator> ().enabled = false;
		GameObject.Find("Torus").GetComponent<Animator> ().enabled = false;
		GameObject.Find("Pyramid").GetComponent<Animator> ().enabled = false;


		StartCoroutine(loop());

	}

	private IEnumerator loop() {

		while (true) {

			yield return new WaitForSeconds(stage_get_speed);
			onTimer();

		}
	}

	private void onTimer() {
		StartCoroutine(Get("http://192.168.11.3:3000/babies/1.json"));

	}

	void Update () {

	}

	Start start = new Start ();

	Score score = new Score ();

	IEnumerator Get (string url) {
		
		Dictionary<string, string> header = new Dictionary<string, string>();
		header.Add ("Accept-Language", "ja");


		WWW www = new WWW (url, null, header);
		yield return www;

		if (www.error == null) {
			
			JsonData  jsonParser = JsonMapper.ToObject(www.text);


			start.team_1 = (bool)jsonParser ["start_1"];
			start.team_2 = (bool)jsonParser ["start_2"];
			start.team_3 = (bool)jsonParser ["start_3"];
			start.team_4 = (bool)jsonParser ["start_4"];

//			Debug.Log (start.team_1);
//			Debug.Log (start.team_2);
//			Debug.Log (start.team_3);
//			Debug.Log (start.team_4);


			if (start.team_1 == true && start_check == false && end_check == false) {
				GameObject.Find("team1_start (1)").GetComponent<Text>().text = "準備OK";
				Debug.Log ("1チーム 準備完了");
			}
			if (start.team_2 == true && start_check == false && end_check == false) {
				GameObject.Find("team2_start (1)").GetComponent<Text>().text = "準備OK";
				Debug.Log ("2チーム 準備完了");
			}
			if (start.team_3 == true && start_check == false && end_check == false) {
				GameObject.Find("team3_start (1)").GetComponent<Text>().text = "準備OK";
				Debug.Log ("3チーム 準備完了");
			}
			if (start.team_4 == true && start_check == false && end_check == false) {
				GameObject.Find("team4_start (1)").GetComponent<Text>().text = "準備OK";
				Debug.Log ("4チーム 準備完了");
			}

			score.team_1 = (int)jsonParser ["team_1"];
			score.team_2 = (int)jsonParser ["team_2"];
			score.team_3 = (int)jsonParser ["team_3"];
			score.team_4 = (int)jsonParser ["team_4"];

			Debug.Log (score.team_1);
			Debug.Log (score.team_2);
			Debug.Log (score.team_3);
			Debug.Log (score.team_4);


			if (start.team_1 == true && start.team_2 == true && start.team_3 == true && start.team_4 == true && start_check == false && end_check == false) {
			
				StartCoroutine(StageBonus(15.0f, .5f));
				StartCoroutine(Stage2Bonus(25.0f, 1.0f));
				StartCoroutine(Stage3Bonus(35.0f, .2f));
				StartCoroutine(StageStop(45.0f, 99999.0f));
				StartCoroutine(LoadStage(50.0f, 99999.0f));
				StartCoroutine(WaitStage(55.0f, 99999.0f));
				StartCoroutine(AnswerStage(57.0f, 99999.0f));

				StartCoroutine(CountdownCoroutine());

			}

				
			if (model_1_count != score.team_1 && model_1_count < score.team_1 && start_check == true && end_check == false) {

				AnimationTurnOn ("Cube");
				StartCoroutine(AnimationTurnOff(.33f, "Cube"));
				Item item = new Item ();
				item.position_x = Random.Range(-65.0f, 700.0f);
				item.position_y = Random.Range(400.0f, 600.0f);
				GameObject.Find("Cube").transform.position = new Vector3 (item.position_x, item.position_y, -74);
				Spawn_1 ();
				//Debug.Log ("team1" + model_1_count);
			}

			if (model_2_count != score.team_2 && model_2_count < score.team_2 && start_check == true && end_check == false) {
				AnimationTurnOn ("Sphere");
				StartCoroutine(AnimationTurnOff(.33f, "Sphere"));
				Item item = new Item ();
				item.position_x = Random.Range(-65.0f, 700.0f);
				item.position_y = Random.Range(400.0f, 600.0f);
				GameObject.Find("Sphere").transform.position = new Vector3 (item.position_x, item.position_y, -74);
				Spawn_2 ();
				//Debug.Log ("team2" + model_2_count);
			}
				
			if (model_3_count != score.team_3 && model_3_count < score.team_3 && start_check == true && end_check == false) {
				AnimationTurnOn ("Torus");
				StartCoroutine(AnimationTurnOff(.33f, "Torus"));
				Item item = new Item ();
				item.position_x = Random.Range(-65.0f, 700.0f);
				item.position_y = Random.Range(400.0f, 600.0f);
				GameObject.Find("Torus").transform.position = new Vector3 (item.position_x, item.position_y, -74);
				Spawn_3 ();
				//Debug.Log ("team3" + model_3_count);
			}

			if (model_4_count != score.team_4 && model_4_count < score.team_4 && start_check == true && end_check == false) {
				AnimationTurnOn ("Pyramid");
				StartCoroutine(AnimationTurnOff(.33f, "Pyramid"));
				Item item = new Item ();
				item.position_x = Random.Range(-65.0f, 700.0f);
				item.position_y = Random.Range(400.0f, 600.0f);
				GameObject.Find("Pyramid").transform.position = new Vector3 (item.position_x, item.position_y, -74);
				Spawn_4 ();
				//Debug.Log ("team4" + model_4_count);
			}

		}

		else{


		}
	}

	// Stage Bonus

	IEnumerator StageBonus(float delay, float time) {
		yield return new WaitForSeconds(delay);

		var renderer = GetComponent<MeshRenderer>();
		renderer.material.mainTexture = stage_1;
		GameObject.Find("navigation").GetComponent<Text>().text = "ボーナスタイム！";
		stage_1.Play();
		stage_get_speed = time;
	}

	IEnumerator Stage2Bonus(float delay, float time) {
		yield return new WaitForSeconds(delay);

		var renderer = GetComponent<MeshRenderer>();
		renderer.material.mainTexture = stage_2;
		stage_2.Play();
		GameObject.Find("navigation").GetComponent<Text>().text = "ボーナスタイム終了";
		stage_get_speed = time;
	}

	IEnumerator Stage3Bonus(float delay, float time) {
		yield return new WaitForSeconds(delay);

		var renderer = GetComponent<MeshRenderer>();
		renderer.material.mainTexture = stage_3;
		stage_3.Play();

		GameObject.Find("navigation").GetComponent<Text>().text = "フィーバータイム！";
		stage_get_speed = time;
	}


	IEnumerator StageStop(float delay, float time) {
		yield return new WaitForSeconds(delay);
		start_check = false;
		end_check = true;
		GameObject.Find("navigation").GetComponent<Text>().text = "フィーバータイム終了";
		stage_get_speed = time;
	}


	IEnumerator LoadStage(float delay, float time) {
		yield return new WaitForSeconds(delay);
		GameObject.Find("navigation").GetComponent<Text>().text = "NOW LOADING...";
		Destroy (GameObject.Find("wall-bottom"));
		stage_get_speed = time;
	}

	IEnumerator WaitStage(float delay, float time) {
		yield return new WaitForSeconds(delay);
		GameObject.Find("navigation").GetComponent<Text>().text = "";
		GameObject.Find("countdown").GetComponent<Text>().text = "結果発表";
		stage_get_speed = time;
	}

	IEnumerator AnswerStage(float delay, float time) {
		yield return new WaitForSeconds(delay);


		GameObject.Find("countdown").GetComponent<Text>().text = "";

		Destroy (GameObject.Find("Cube"));
		Destroy (GameObject.Find("Sphere"));
		Destroy (GameObject.Find("Torus"));
		Destroy (GameObject.Find("Pyramid"));

		var renderer = GetComponent<MeshRenderer>();

		ArrayList score = new ArrayList();
		score.Add(model_1_count); 
		score.Add(model_2_count); 
		score.Add(model_3_count); 
		score.Add(model_4_count); 
		score.Sort();

		if ((int)score[3] == model_1_count && (int)score[2] == model_2_count) { // 1位が青チームで2位が赤チームだったら
			renderer.material.mainTexture = blu_fish;
			blu_fish.loop = true;
			blu_fish.Play ();
			StartCoroutine(Win(10.0f, "青チームの勝利です"));

		} else if ((int)score[3] == model_1_count && (int)score[2] == model_3_count) { // 1位が青チームで2位が黄チームだったら
			renderer.material.mainTexture = blu_dragon;
			blu_dragon.loop = true;
			blu_dragon.Play();
			StartCoroutine(Win(10.0f, "青チームの勝利です"));

		} else if ((int)score[3] == model_1_count && (int)score[2] == model_4_count) { // 1位が青チームで2位が緑チームだったら
			renderer.material.mainTexture = blu_umbrella;
			blu_umbrella.loop = true;
			blu_umbrella.Play();
			StartCoroutine(Win(10.0f, "青チームの勝利です"));

		}



		else if ((int)score[3] == model_2_count && (int)score[2] == model_1_count) { // 1位が赤チームで2位が青チームだったら
			renderer.material.mainTexture = red_apple;
			red_apple.loop = true;
			red_apple.Play ();
			StartCoroutine(Win(10.0f, "赤チームの勝利です"));
		} else if ((int)score[3] == model_2_count && (int)score[2] == model_3_count) { // 1位が赤チームで2位が黄チームだったら
			renderer.material.mainTexture = red_suzaku;
			red_suzaku.loop = true;
			red_suzaku.Play();
			StartCoroutine(Win(10.0f, "赤チームの勝利です"));
		} else if ((int)score[3] == model_2_count && (int)score[2] == model_4_count) { // 1位が赤チームで2位が緑チームだったら
			renderer.material.mainTexture = red_airplane;
			red_airplane.loop = true;
			red_airplane.Play();
			StartCoroutine(Win(10.0f, "赤チームの勝利です"));
		}





		else if ((int)score[3] == model_3_count && (int)score[2] == model_1_count) { // 1位が黄チームで2位が青チームだったら
			renderer.material.mainTexture = yel_duck;
			yel_duck.loop = true;
			yel_duck.Play();
			StartCoroutine(Win(10.0f, "黄チームの勝利です"));
		} else if ((int)score[3] == model_3_count && (int)score[2] == model_2_count) { // 1位が黄チームで2位が赤チームだったら
			renderer.material.mainTexture = yel_butterfly;
			yel_butterfly.loop = true;
			yel_butterfly.Play();
			StartCoroutine(Win(10.0f, "黄チームの勝利です"));
		} else if ((int)score[3] == model_3_count && (int)score[2] == model_4_count) { // 1位が黄チームで2位が緑チームだったら
			renderer.material.mainTexture = yel_tiger;
			yel_tiger.loop = true;
			yel_tiger.Play();
			StartCoroutine(Win(10.0f, "黄チームの勝利です"));
		}





		else if ((int)score[3] == model_4_count && (int)score[2] == model_1_count) { // 1位が緑チームで2位が青チームだったら
			renderer.material.mainTexture = gre_flower;
			gre_flower.loop = true;
			gre_flower.Play();
			StartCoroutine(Win(10.0f, "緑チームの勝利です"));
		} else if ((int)score[3] == model_4_count && (int)score[2] == model_2_count) { // 1位が緑チームで2位が赤チームだったら
			renderer.material.mainTexture = gre_frog;
			gre_frog.loop = true;
			gre_frog.Play();

			StartCoroutine(Win(10.0f, "緑チームの勝利です"));
		} else if ((int)score[3] == model_4_count && (int)score[2] == model_3_count) { // 1位が緑チームで2位が黄チームだったら
			renderer.material.mainTexture = gre_genbu;
			gre_genbu.loop = true;
			gre_genbu.Play();
			StartCoroutine(Win(10.0f, "緑チームの勝利です"));
		}



		stage_get_speed = time;
	}



	IEnumerator Win(float delay, string text) {
		yield return new WaitForSeconds(delay);
		GameObject.Find("navigation").GetComponent<Text>().text = text;
	}


	// Animation

	IEnumerator AnimationTurnOff(float delay, string obj) {
		yield return new WaitForSeconds(delay);
		GameObject.Find(obj).GetComponent<Animator> ().enabled = false;
	}

	void AnimationTurnOn(string obj) {
		GameObject.Find(obj).GetComponent<Animator> ().enabled = true;
	}


	// Spawn prefab
	void Spawn_1 ()
	{
		Instantiate(Cube, GameObject.Find("Cube").transform.position, Quaternion.identity);
		model_1_raw = score.team_1;
		model_1_count++;
	}

	void Spawn_2 ()
	{
		Instantiate(Sphere, GameObject.Find("Sphere").transform.position, Quaternion.identity);
		model_2_raw = score.team_2;
		model_2_count++;
	}

	void Spawn_3 ()
	{
		Instantiate(Torus, GameObject.Find("Torus").transform.position, Quaternion.identity);
		model_3_raw = score.team_3;
		model_3_count++;
	}

	void Spawn_4 ()
	{
		Instantiate(Pyramid, GameObject.Find("Pyramid").transform.position, Quaternion.identity);
		model_4_raw = score.team_4;
		model_4_count++;
	}


	IEnumerator CountdownCoroutine()
	{	
		if(start.team_1 == true && start.team_2 == true && start.team_3 == true && start.team_4 == true && start_check == false && end_check == false) {
		GameObject.Find("countdown").GetComponent<Text>().text = "3";
		yield return new WaitForSeconds(1.0f);

		GameObject.Find("countdown").GetComponent<Text>().text = "2";
		yield return new WaitForSeconds(1.0f);

		GameObject.Find("countdown").GetComponent<Text>().text = "1";
		yield return new WaitForSeconds(1.0f);

		GameObject.Find("countdown").GetComponent<Text>().text = "スタート";
		yield return new WaitForSeconds(1.0f);

		GameObject.Find("countdown").GetComponent<Text>().text = "";
		start_check = true;

		GameObject.Find ("team1_start (1)").GetComponent<Text>().text = "";
		GameObject.Find ("team2_start (1)").GetComponent<Text>().text = "";
		GameObject.Find ("team3_start (1)").GetComponent<Text>().text = "";
		GameObject.Find ("team4_start (1)").GetComponent<Text>().text = "";
		}
	}

}
