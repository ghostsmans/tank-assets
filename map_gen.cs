
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq;
using System.IO;


public class map_gen : MonoBehaviour {
    public int x_start = 0, y_start = 0;
    public GameObject I_wall, II_wall, L_wall, U_wall, plane, tank, tank2;
    public GameObject map_camera;

    /*private void run_cmd()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "C:\\Users\\ghost\\PycharmProjects\\untitled\\venv\\Scripts\\python.exe";
        start.Arguments = "C:\\Users\\ghost\\попытка2\\gen.py";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                UnityEngine.Debug.Log(result);
                Console.ReadLine();
            }
        }
    }*/

    // Use this for initialization
    void Start () {

        Process myProcess = new Process();
        System.Diagnostics.Process.Start("C:\\Users\\ghost\\попытка2\\gen.exe");
        try
        {
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "gen.exe";
            myProcess.StartInfo.CreateNoWindow = true;
            string line = myProcess.StandardOutput.ReadLine();
            Console.WriteLine(line);
            myProcess.Start();
            //run_cmd();
            /*var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\\Users\\ghost\\PycharmProjects\\untitled\\venv\\Scripts\\python.exe",
                    Arguments = "/c \"gen.exe\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = @"Python C:\\Users\\ghost\\попытка2"
                }
            };*/

            //proc.Start();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.Log(e.Message);
        }
        
        string[] lines = System.IO.File.ReadAllLines(@"C:\\Users\\ghost\\попытка2\\map.txt");
        string[] values = lines[0].Split(' ').ToArray();
        int[] asIntegers = values.Select(s => int.Parse(s)).ToArray();
        int h = asIntegers[0], w = asIntegers[1];



        Dictionary<int, int[]> f11 = new Dictionary<int, int[]>();
        for (int i = 1; i < w * h + 1; i++)
        {
            asIntegers = lines[i].Split(' ').Select(s => int.Parse(s)).ToArray();
            f11[i] = asIntegers;
        }
        /*f11[1] = new List<int>() { 2 };
        f11[2] = new List<int>() { 1, 3 };
        f11[3] = new List<int>() { 2, 4, 7 };
        f11[4] = new List<int>() { 3, 8 };
        f11[5] = new List<int>() { 9 };
        f11[6] = new List<int>() { 10 };
        f11[7] = new List<int>() { 3, 11 };
        f11[8] = new List<int>() { 4 };
        f11[9] = new List<int>() { 5, 10 };
        f11[10] = new List<int>() { 6, 9, 11, 14 };
        f11[11] = new List<int>() { 7, 10, 12 };
        f11[12] = new List<int>() { 11, 16 };
        f11[13] = new List<int>() { 14, 17 };
        f11[14] = new List<int>() { 10, 13, 18 };
        f11[15] = new List<int>() { 19 };
        f11[16] = new List<int>() { 12 };
        f11[17] = new List<int>() { 13 };
        f11[18] = new List<int>() { 14, 19 };
        f11[19] = new List<int>() { 15, 18, 20 };
        f11[20] = new List<int>() { 19 };
        */
        for (int i = 1; i < h * w + 1; i++)
        {
            int[] a = f11[i];
            Boolean up = false, down = false, left = false, right = false;

            //Tile type
            if (Array.IndexOf(a, i - 1) != -1)
            {
                left = true;
            }
            if (Array.IndexOf(a, i + 1) != -1)
            {
                right = true;
            }
            if (Array.IndexOf(a, i - w) != -1)
            {
                down = true;
            }
            if (Array.IndexOf(a, i + w) != -1)
            {
                up = true;
            }

            //Tile spawning
            if (!up && down && !left && !right)
            {
                Instantiate(U_wall, new Vector3(2*((i-1)%w+1), 0, 2*((i-1)/w+1)), Quaternion.Euler(0, 180, 0));
            }
            if (up && !down && !left && !right)
            {
                Instantiate(U_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 0, 0));
            }
            if (!up && !down && left && !right)
            {
                Instantiate(U_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 270, 0));
            }
            if (!up && !down && !left && right)
            {
                Instantiate(U_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 90, 0));
            }
            if (up && down && left && right)
            {
                Instantiate(plane, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(90, 0, 0));
            }
            if (up && down && !left && !right)
            {
                Instantiate(II_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 0, 0));
            }
            if (!up && !down && left && right)
            {
                Instantiate(II_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 90, 0));
            }
            if (up && right && !down && !left)
            {
                Instantiate(L_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 90, 0));
            }
            if (up && left && !down && !right)
            {
                Instantiate(L_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 0, 0));
            }
            if (right && down && !up && !left)
            {
                Instantiate(L_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 180, 0));
            }
            if (left && down && !up && !right)
            {
                Instantiate(L_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 270, 0));
            }
            if (!right && left && up && down)
            {
                Instantiate(I_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 0, 0));
            }
            if (!down && left && up && right)
            {
                Instantiate(I_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 90, 0));
            }
            if (!left && down && right && up)
            {
                Instantiate(I_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 180, 0));
            }
            if (!up && right && down && left)
            {
                Instantiate(I_wall, new Vector3(2 * ((i - 1) % w + 1), 0, 2 * ((i - 1) / w + 1)), Quaternion.Euler(0, 270, 0));
            }

        }
        GameObject first = Instantiate(tank, new Vector3(2, 1, 2), Quaternion.identity);
        first.gameObject.GetComponent<tank_controller>().name = "First Tank";
        //GameObject second = Instantiate(tank2, new Vector3(w * 2, 1, h * 2), Quaternion.Euler(0, 180, 0));
        //second.gameObject.GetComponent<tank_controller>().name = "Second Tank";
        map_camera.transform.position += new Vector3(h+1, 0, w-7);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
