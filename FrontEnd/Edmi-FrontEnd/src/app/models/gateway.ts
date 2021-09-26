export class Gateway{
	
	constructor(
		public _id       :string,
		public serialNumber      :string,
		public firmwareVersion      :String,
		public state    :string,
        public ip      :String,
		public port    :string
		) {
	
	}
}