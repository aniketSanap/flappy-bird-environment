# Unity environment for reinforcement learning

### Actions
There is only one action: jump (1)
Not jumping is treated as 0

### Rewards
The agent gets +1 reward for every time step it is alive and -10 penalty when it dies.
Death is caused by going off screen or colliding with the pipes (seaweed)

### Note
This is my first Unity project so I am sure there are areas which can be improved and I encourage you to do so.
Every reference to 'seaweed' in the code is actually the pipes as there were originally seaweed but that seems to add complexity to the environment making it harder for the model to train.