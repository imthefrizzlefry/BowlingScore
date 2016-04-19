# Bowling Score program
Scoring for bowling
Each turn for bowling is called a frame. Each frame starts with a setup of 10 pins. A game consists of 10
frames, with two balls allowed a bowler in each frame. Each pin knocked down counts one point. Toppling all
pins with the first ball is a strike and scores 10 points plus the total of the next two balls. Clearing the alley with
two balls is a spare and scores 10 points plus the next roll. A perfect game, 300 points, requires 12
consecutive strikes.
### Examples:
1. In the first frame, with the first ball, 5 pins are knocked down. 5 pins remain standing. The second ball knocks
down 4 pins. The total score for the frame is 9 points.
2. In the second frame, the first ball knocks down all 10 pins. The second ball is not used for this frame, as there
are no pins remaining. In the third frame, 5 pins are knocked down on the first ball, and 3 pins are knocked
down on the second ball. Now that 2 additional balls have been thrown, the total score for the second frame
can be computed as 10 (second frame) + 5 + 3 (number of pins knocked down with the next two balls). The
second frame score is 18, and the total score at the second frame is 27. The third frame is worth 8 points, and
the total score as of the third frame is now 35 points.
3. Considerations in the 10th frame: If the tenth frame is a strike or a spare, the pins are reset and the bowler is
allowed additional rolls to account for the score of the extra one or two balls. These scores are only to add to
the tenth frame score, and do not score by themselves.

## Scoring program
Please write a program to compute the score of a game, given a list of integers representing the count of pins
knocked down with each ball.
The signature of the primary method should be:
public static int ComputeScore(List<int> perBallScores)
The output of the method should be the total score of the game, or ­1 if the input is invalid in any way. All runs
should result in a result.
## Unit Tests
In addition to the scoring program, please provide test cases which cover the methods utilized. This is a key
part of the requirement, as the intent is to evaluate the various test cases that you can come up with to verify
the correctness of the program.
## Samples
The following are some starting sample inputs and outputs. Please do not limit yourself to these.
10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 = 300
2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 = 40
1, 2, 3, 4 = ­1 (not enough ball scores provided)
## Deliverable
Please provide a C# console application ­ include the solution file, the program and the tests. Please do not
include any binary files.
## Evaluation
The evaluation of the submission will be made by several factors:
­ Does the submission adhere to the instructions
­ Readability of the code
­ Testability of the solution design
­ Correctness of the solution
­ Handling of invalid or error cases
­ Test coverage for the solution, both at the level of the ComputeScore method, as well as any
underlying methods utilized
