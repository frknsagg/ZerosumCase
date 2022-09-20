# ZerosumCase

/* Hey there! This is the case project that given by Zerosum Company
 * 
 *
 * Main Target :
 * The character collects stacks and currencies and avoid obstacles while moving through the level towards finish line.
 *
 * 
 * UI
 * -----
 *
 * There are 3 screens :
 * - Tap To Play
 * - In Game
 * - Level End
 *
 *  Tap To Play :
 *      This screen appear before starting a new level.
 * 
 *      It includes ;
 *      -Tap To Play Button and Text
 *      -Current Level Number
 *      -Currency Amount
 *      -Start Stack Upgrade Button & Price
 *
 *      Start Stack Upgrade Button :
 *      This button consume our currency and increase our starting stack.
 *
 *  In Game :
 *      This screen appear while we are controlling the character.
 *
 *      It includes ;
 *      -Current Level Number
 *      -Currency Amount
 *      -Stack Amount
 *
 *      Stack Amount :
 *      This must be attached to and move with the character as smooth as possible.
 *
 *  Level End :
 *      This screen appear after we reached our finish line.
 *
 *      It includes ;
 *      -Level Completed Text
 *      -Collected Currency Amount
 *      -Next Level Button
 *
 * UI elements responsive and works well with different resolutions.
 *      
 * GAMEPLAY
 * -----
 *
 *  Input :
 *      Character moves left and right with drag input.
 *      Movement simple and as smooth as possible.
 *
 *  Character :
 *      Character moves with the given animations.
 *      Character have maximum stack limit.
 *      Character animations have transition between them.
 *          If there is no stack "Run1", if stack is full "Run2" plays.
 *          States have between also  affect the animation.
 *      Transitions  as smooth as possible.
 *      On Level End, character dances.
 *
 *  Collectables :
 *      There are 2 types of collectables
 *      -Stack
 *      -Currency
 *
 *      Stack : Increase out total stack amount.
 *      Currency :Increase out total currency amount.
 *      
 *  Obstacles :
 *      Obstacles covers a part of the road.
 *      If character cannot avoid them, current stack amount decreases.
 *
 *

