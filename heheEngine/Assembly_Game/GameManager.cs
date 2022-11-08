
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heheEngine
{
    public class GameManager : ScriptComponent
    {

        public static GameManager gameManagerInstance;

        // params
        private GameObject player;
        /*
        private void Awake()
        {
            //DontDestroyOnLoad(this);

            if (gameManagerInstance == null)
            {
                gameManagerInstance = this;
            }
            else
            {
                GameObject.Destroy(this.gameObject);
            }
        }
        */
        public void Start()
        {
            player = GameObject.Find("Player");
        }

        public void Update()
        {

        }
    }
}
