pragma solidity >=0.4.0 <0.6.2;

/*===================================================================================

                                MAIN BALLOT

===================================================================================*/

contract Ballot_Main {

    Ballots[] private ballots; //Ballot Arrays, stored addresses of spawn ballots
    address private main_owner; //variable for contract owner
    address private main_address;
    bytes32 private key;//storage for validation key


    constructor(bytes32 _key) public { // Constructor for Deploying Contract
        main_owner = msg.sender; //Address of Sender will become Owner of the Main Contract
        main_address = address(this);
        key = _key;
    }

    function VoteDetails_district (address addr, bytes32 _voter_id, bytes32 _key) public view returns(
            bytes32,
            bytes32,
            bytes32,
            bytes32
        ) {
            require(
            _key == key,"MAIN: Access not allowed"
        );// function to get voter details
        Ballots b = Ballots(addr);
        return b.Vote_Details(_voter_id, _key);
    }


    function spawn_ballot(bytes32 _district, bytes32 _sub_key,bytes32 _key) public  { //Function to for spawning child contract/ballots
                  require(
           _key == key,"MAIN: Access not allowed"
        );                                                  // Requires an Array of Districts (bytes32)
        Ballots new_ballot = new Ballots(key, _sub_key, _district); // Initializes a new ballot with different district
        ballots.push(new_ballot); //pushes instance of ballot in ballot
    }

    function getDeployedChildContracts(bytes32 _key) public  view returns (Ballots) { // Function to return address of the last ballot
    require(_key == key,"MAIN: Access not allowed");
      return ballots[ballots.length-1];
    }

    function all_ballots(bytes32 _key) public view returns (Ballots) { // Function to return address of all ballot instances
    require(
           _key == key,"MAIN: Access not allowed"
        );
      return ballots[ballots.length];
    }

    function return_address() public view returns (address) { // Function to return address of all ballot instances
      return main_owner;
    }

}

/*===================================================================================

                                CHILD BALLOT

===================================================================================*/

contract Ballots {

    bytes32 private main_key;
    bytes32 private sub_key;
    bytes32 private district;

    struct Voter { //struct for Voters in Child Ballot
        bytes32 voter_id;
        uint8 exists;
        bytes32 precint_no;
    }

    struct Vote { //struct for Voters in Child Ballot
        bytes32 voter_id;
        bytes32 voteStringA;
        bytes32 voteStringB;
        bytes32 vote_datetime;
    }

    mapping (bytes32 => Voter) district_voters; // mapping of district voters
    mapping (bytes32 => Vote) district_votes; // mapping of district voters

    constructor (
        bytes32 _main_key,
        bytes32 _sub_key,
        bytes32 _district) public { //construct for deploying sub ballot contracts
         // this is called in main ballot

        main_key = _main_key;
        sub_key = _sub_key;
        district =_district; //district from main ballot is assigned in sub ballot district
    }

    function vote(
       bytes32 _voteStringA,
       bytes32 _voteStringB,
       bytes32 _voter_id,
       bytes32 _vote_date,
       bytes32 _key) public { // The Vote function for voters
       require(_key == sub_key,"SUB: Access not allowed");

        district_votes[_voter_id].voter_id = _voter_id;
        district_votes[_voter_id].voteStringA = _voteStringA;
        district_votes[_voter_id].voteStringB = _voteStringB;
        district_votes[_voter_id].vote_datetime = _vote_date;
    }

    function Vote_Details(bytes32 _voter_id, bytes32 _key) public view returns(
            bytes32,
            bytes32,
            bytes32,
            bytes32) {
        require(_key == sub_key || _key == main_key, "SUB: Access not allowed"
        );
        return (
           district_votes[_voter_id].voter_id,
           district_votes[_voter_id].voteStringA,
           district_votes[_voter_id].voteStringB,
           district_votes[_voter_id].vote_datetime
           );
    }

    function checkVoterExists(bytes32 _voter_id) public view returns(uint8, bytes32) {
       return (district_voters[_voter_id].exists,district_voters[_voter_id].precint_no);
    }

    function registerVoter(bytes32 _voter_id, bytes32 _precint_no, bytes32 _key) public { // function to register voter using voter id
        require(_key == sub_key, "SUB: Access not allowed"
            );
        district_voters[_voter_id].exists = 1;
        district_voters[_voter_id].precint_no = _precint_no;
    }
}