﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSach.database.models
{
    public enum Status_borrow
    {
        Pending,
        Borrowed,
        Canceled,
        Completed
    }
    public class Register
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime register_at { get; set; }

        private DateTime? _borrow_at;
        private DateTime? _return_at;
        private DateTime? _expected_at { get; set; }

        public DateTime? borrow_at
        {
            get
            {
                if (this.Status == Status_borrow.Borrowed || this.Status == Status_borrow.Completed)
                    return _borrow_at;
                return null;
            }
            set
            {
                _borrow_at = value;
            }
        }

        public DateTime? expected_at
        {
            get
            {
                if (this.Status == Status_borrow.Canceled)
                    return null;
                return register_at.AddDays(7);
            }
            set
            {
                _expected_at = value;
            }
        }

        public DateTime? return_at
        {
            get
            {
                if (this.Status == Status_borrow.Completed)
                    return _return_at;
                return null;
            }
            set
            {
                _return_at = value;
            }
        }


        public Status_borrow Status { get; set; }
    }
}